using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeleMedic.Ambulance
{
    public class HL7Listener
    {
        private byte[] Localhost = { 192, 168, 0, 81 };
        private const int Port = 7777;
        public event EventHandler<HL7MessageEventArgs> OnMessageReceived;


        public HL7Listener()
        {

        }

        public void Start()
        {
            System.Net.IPAddress address = new IPAddress(Localhost);
            System.Net.IPEndPoint endPoint = new IPEndPoint(address, Port);

            try
            {
                // Create a thread for listening to a port.
                Subscriber subscriber = new Subscriber(endPoint);
                subscriber.OnMessageReceived += Subscriber_OnMessageReceived;
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

        private void Subscriber_OnMessageReceived(object sender, HL7MessageEventArgs e)
        {
            if (OnMessageReceived != null)
                OnMessageReceived(this, e);

        }
    }
}
