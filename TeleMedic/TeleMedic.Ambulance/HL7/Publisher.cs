﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TeleMedic.Ambulance
{
    public class Publisher
    {
        private System.Net.Sockets.Socket sender;
        byte[] localhost;
        int port;
        public Publisher(byte[] localhost, int port)
        {
            this.localhost = localhost;
            this.port = port;
        }

        public void Send()
        {
            IPAddress address = new IPAddress(localhost);
            IPEndPoint endPoint = new IPEndPoint(address, port);

            while (true)
            {
                try
                {
                    sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(endPoint);
                    byte[] hl7Data = System.IO.File.ReadAllBytes(@"C:\Temp\HL7Listener\HL7Listener\HL7Listener\Resources\SampleHL7.hl7");
                    int dataLength = hl7Data.Length;
                    byte[] dataToSend = new byte[dataLength + 3];
                    dataToSend[0] = 0x0b; // Add a Vertical Tab (VT) character
                    Array.Copy(hl7Data, 0, dataToSend, 1, dataLength);
                    dataToSend[dataLength + 1] = 0x1c; // Add File Separator (FS) charachter
                    dataToSend[dataLength + 2] = 0x0d; // Add carriage return (CR) charachter
                    sender.SendBufferSize = 4096;
                    try
                    {
                        sender.Send(dataToSend);
                        Console.WriteLine("HL7 message sent.");
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        // Exception handling
                    }
                    System.Threading.Thread.Sleep(5000);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    // Exception handling
                }
                finally
                {
                    sender.Close();
                }
            }
        }
    }
}
