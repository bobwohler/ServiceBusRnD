using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;

namespace ServiceBusConsoleApp
{
    class Program
    {
        //TODO: move some of these settings to config file. 
        static string ServerFQDN;
        static int HttpPort = 9355;
        static int TcpPort = 9354;
        static string ServiceNamespace = "ServiceBusDefaultNamespace";
        const string QueueName = "ServiceBusQueueSample";

        static void Main(string[] args)
        {
            // Get the executing server's FQDN...this will be used for the Host paroperty of the sb endpoint.
            // I initially neglected to populate this value which resulted in errors resolving the namespace at 
            // runtime when an attempt was made to connect to the sb instance.
            ServerFQDN = System.Net.Dns.GetHostEntry(string.Empty).HostName;

            // Build the Service Bus connection string
            ServiceBusConnectionStringBuilder connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = HttpPort;
            connBuilder.RuntimePort = TcpPort;
            connBuilder.Endpoints.Add(new UriBuilder()
            {
                Scheme = "sb", // this scheme is for TCP
                Host = ServerFQDN,
                Path = ServiceNamespace
            }.Uri);
            connBuilder.StsEndpoints.Add(new UriBuilder()
            {
                Scheme = "https",
                Host = ServerFQDN,
                Port = HttpPort,
                Path = ServiceNamespace
            }.Uri);

            //TODO: Identify specifics of purpose of 
            // NamespaceManager instance...
            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString());
            MessagingFactory messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString());

            // Now create queue on the fly
            if (namespaceManager == null)
            {
                Console.WriteLine("\nUnexpected Error: NamespaceManager is NULL");
                return;
            }
            if (namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.DeleteQueue(QueueName);
            }
            namespaceManager.CreateQueue(QueueName);

            // Create a queue client to send and receive messages to and from the queue
            QueueClient queueClient = messageFactory.CreateQueueClient(QueueName);

            // Create a simple brokered message and send it to the queue.
            BrokeredMessage messageToSend = new BrokeredMessage("Hello World! I used to GitHub with this solution!");
            queueClient.Send(messageToSend);

            // Receive the message back from the queue.
            BrokeredMessage receivedMessage = queueClient.Receive(TimeSpan.FromSeconds(5));
            if (receivedMessage != null)
            {
                Console.WriteLine(string.Format("Message rceived: Body = {0}",
                  receivedMessage.GetBody<string>()));
                receivedMessage.Complete();
            }

            // Clean up.
            if (messageFactory != null)
            {
                messageFactory.Close();
            }
            Console.ReadLine();
        }
    }
}
