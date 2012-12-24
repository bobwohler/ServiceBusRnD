using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace ServiceBusConsoleApp
{
    class AlternateCodeToTry
    {
        ////define variables
        //string servername = "WA1BTDISEROSB01";
        //int httpPort = 4446;
        //int tcpPort = 9354;
        //string sbNamespace = "NsSeroterDemo";
        ////create SB uris
        //Uri rootAddressManagement = ServiceBusEnvironment.CreatePathBasedServiceUri("sb", sbNamespace, string.Format("{0}:{1}", servername, httpPort));
        //Uri rootAddressRuntime = ServiceBusEnvironment.CreatePathBasedServiceUri("sb", sbNamespace, string.Format("{0}:{1}", servername, tcpPort));
        ////create NS manager
        //NamespaceManagerSettings nmSettings = new NamespaceManagerSettings();
        //nmSettings.TokenProvider = TokenProvider.CreateWindowsTokenProvider(new List() { rootAddressManagement });
        //NamespaceManager namespaceManager = new NamespaceManager(rootAddressManagement, nmSettings);
        ////create factory
        //MessagingFactorySettings mfSettings = new MessagingFactorySettings();
        //mfSettings.TokenProvider = TokenProvider.CreateWindowsTokenProvider(new List() { rootAddressManagement });
        //MessagingFactory factory = MessagingFactory.Create(rootAddressRuntime, mfSettings);
        ////check to see if topic already exists
        //if (!namespaceManager.QueueExists("OrderQueue"))
        //{
        //     MessageBox.Show("queue is NOT there ... creating queue");
        //     //create the queue
        //     namespaceManager.CreateQueue("OrderQueue");
        //}
        //else
        //{
        //      MessageBox.Show("queue already there!");
        //}
    }
}