using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Serverside
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(8888); // Constructor 8888 is port for listening
            server.Start();
            Console.WriteLine("Server started and waiting for client.");

            // Step-2 Create Socket where client communicate with server
            Socket socketForClients = server.AcceptSocket();

            if (socketForClients.Connected)
            {
                // Server creates virtual file through network stream
                NetworkStream ns = new NetworkStream(socketForClients);
                // Send message to client
                StreamWriter sw = new StreamWriter(ns); // ns gives path of the file
                //Console.WriteLine("Message from server for Client:: Welcome to server");
                sw.WriteLine("Welcome Client");
                sw.WriteLine("Enter your age:");
                sw.WriteLine("Welcome Client");

                sw.Flush(); // it push message to network stream

                // Code for reading data from Client
                StreamReader sr = new StreamReader(ns);
                // Console.WriteLine("HEre is Message from Client" + sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine()); Console.WriteLine(sr.ReadLine()); Console.WriteLine(sr.ReadLine());
                // Close the socket
                socketForClients.Close();


            }
        }
    }
}
