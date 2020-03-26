using System;
using System.Net.Sockets;
using System.IO;

namespace ClientSideChat
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            client = new TcpClient("127.0.0.1", 8888);
            NetworkStream ns = client.GetStream();
       
            StreamReader sr = new StreamReader(ns);

            Console.WriteLine(sr.ReadLine());
            string age = Console.ReadLine();
            Console.WriteLine(age);
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());

            // Send some message to Server from CLIENT
            StreamWriter sww = new StreamWriter(ns);
            //Console.WriteLine("Message from Client to Server is :");
            //sw.WriteLine("\nHello From Client to Server ");
            //sw.Flush();
            NetworkStream nsw = client.GetStream();
            StreamWriter sw = new StreamWriter(nsw);
            sww.WriteLine("hello from Client1");
            sww.WriteLine("hello from Client2");
            sww.WriteLine("hello from Client3");
            sww.Flush();

            sw.Close();
            ns.Close();

        }
    }
}
