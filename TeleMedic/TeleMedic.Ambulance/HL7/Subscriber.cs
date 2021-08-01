﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TeleMedic.Ambulance
{
    public class Subscriber
    {
        private System.Net.Sockets.Socket listener;
        private IPEndPoint endPoint;

        public event EventHandler<HL7MessageEventArgs> OnMessageReceived;

        public Subscriber(IPEndPoint endPoint)
        {
            this.endPoint = endPoint;
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(endPoint);
            Console.WriteLine("Listening to port {0}", endPoint);
            listener.Listen(3);
        }

        public void Listen()
        {
            // Declare your variables.
            // Do not declare variables inside loops like for, foreach, while etc.
            // Because with every iteration, a new variable will be created.
            // If your loop iterates 1000 times, you will end up creating 1000 variables instead of just one variable.
            byte[] buffer;
            int count;
            string data;
            string tempData;
            string response = String.Empty;
            int start;
            int end;
            try
            {
                // true here make sure that the thread keep listening to the port.
                while (true)
                {
                    buffer = new byte[4096];

                    // Take care of incoming connection ...
                    Socket receiver = listener.Accept();
                    Console.WriteLine("Taking care of incoming connection.");
                    // Handle the message if one is received.
                    while (true)
                    {
                        count = receiver.Receive(buffer);
                        data = Encoding.UTF8.GetString(buffer, 0, count);

                        // Search for a Vertical Tab (VT) character to find start of MLLP frame.
                        start = data.IndexOf((char)0x0b);
                        if (start >= 0)
                        {
                            // Search for a File Separator (FS) character to find the end of the frame.
                            end = data.IndexOf((char)0x1c);
                            if (end > start)
                            {
                                // Remove the MLLP charachters
                                tempData = Encoding.UTF8.GetString(buffer, 4, count - 12);
                                // Do what you want with the received message
                                response = HandleMessage(tempData);

                                // Send response
                                receiver.Send(Encoding.UTF8.GetBytes(response));
                                Console.WriteLine("Acknowledgment sent.");
                                break;
                            }
                        }
                    }

                    // close connection
                    receiver.Shutdown(SocketShutdown.Both);
                    receiver.Close();

                    Console.WriteLine("Connection closed.");
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                // Exception handling
            }
        }

        private string HandleMessage(string data)
        {
            string responseMessage = String.Empty;
            try
            {
                Console.WriteLine("Message received.");

                Message msg = new Message();
                msg.DeSerializeMessage(data);


                // You can do what you want with the message here as per your appliation requirements.
                // For eg: read patient ID, patient last name, age etc.
                if (OnMessageReceived != null)
                    OnMessageReceived(this, new HL7MessageEventArgs(msg));
                // Create a response message
                //
                responseMessage = CreateRespoonseMessage(msg.MessageControlId());
            }
            catch (Exception ex)
            {
                // Exception handling
            }
            return responseMessage;
        }

        private string CreateRespoonseMessage(string messageControlID)
        {
            try
            {
                Message response = new Message();

                Segment msh = new Segment("MSH");
                msh.Field(2, "^~\\&");
                msh.Field(7, DateTime.Now.ToString("yyyyMMddhhmmsszzz"));
                msh.Field(9, "ACK");
                msh.Field(10, Guid.NewGuid().ToString());
                msh.Field(11, "P");
                msh.Field(12, "2.5.1");
                response.Add(msh);

                Segment msa = new Segment("MSA");
                msa.Field(1, "AA");
                msa.Field(2, messageControlID);
                response.Add(msa);


                // Create a Minimum Lower Layer Protocol (MLLP) frame.
                // For this, just wrap the data lik this: <VT> data <FS><CR>
                StringBuilder frame = new StringBuilder();
                frame.Append((char)0x0b);
                frame.Append(response.SerializeMessage());
                frame.Append((char)0x1c);
                frame.Append((char)0x0d);

                return frame.ToString();
            }
            catch (Exception ex)
            {
                // Exception handling

                return String.Empty;
            }
        }
    }

    public class HL7MessageEventArgs
    {
        public Message Message { get; set; }
        public HL7MessageEventArgs(Message message)
        {
            Message = message;
        }
    }
}
