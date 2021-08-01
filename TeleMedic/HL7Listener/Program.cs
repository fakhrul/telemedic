using System;
using System.Net;
using System.Threading;

namespace HL7Listener
{
    class Program
    {
        private static readonly byte[] Localhost = { 192, 168, 0, 81};
        private const int Port = 7777;

        static void Main(string[] args)
        {
            System.Net.IPAddress address = new IPAddress(Localhost);
            System.Net.IPEndPoint endPoint = new IPEndPoint(address, Port);

            try
            {
                // Create a thread for listening to a port.
                Subscriber subscriber = new Subscriber(endPoint);
                System.Threading.Thread listnerThread = new Thread(new ThreadStart(subscriber.Listen));
                listnerThread.Start();
                // Craete another thread for sending HL7 messages
                // Send Message so that the listening port catches it.
                //Publisher publisher = new Publisher(Localhost, Port);
                //Thread senderThread = new Thread(new ThreadStart(publisher.Send));
                //senderThread.Start();
            }
            catch (Exception e)
            {
                // Exception handling
                Console.WriteLine("An unexpected exception occured: {0}", e.Message);
            }
        }
    }
}
