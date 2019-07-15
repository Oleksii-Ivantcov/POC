using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using SysProc;

//Process p = (Process)formatter.Deserialize(strm);
//Console.WriteLine("Process Name: " + p.ProcessName + " Location:" + p.Loc + " size " + p.Size + " kb.");

namespace ServerPOC
{
    class Program
    {
        public static void Main()
        {



            TcpListener server = new TcpListener(8888);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream strm = client.GetStream();
                byte[] data = new byte[256];
                int bytes = strm.Read(data, 0, data.Length); // получаем количество считанных байтов
                string message = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine(message);
            }
            //Handler(ps, strm);


            //strm.Close();
            //client.Close();
            server.Stop();
            Console.ReadKey();
        }

        public static void Handler(Commands ps, NetworkStream strm)
        {
            switch (ps.Command)
            {
                case ProcessCommand.Start:
                    {
                        if (ps.Loc == null) throw new ArgumentNullException();
                        try
                        {
                            var startingProcess = Process.Start(ps.Loc);
                            string response = "Process run";
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            strm.Write(data, 0, data.Length);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;
                    }
                case ProcessCommand.GetProcess:
                    {
                        var poc = Process.GetProcesses();
                        break;
                    }
            }
        }
    }
}
