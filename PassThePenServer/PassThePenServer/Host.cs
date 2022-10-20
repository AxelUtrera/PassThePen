using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PassThePenServer
{
    internal class Host
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(Comunication.PlayerMgt)))
            {
                host.Open();
                Console.WriteLine("Server is up...");
                Console.ReadLine();
            }
            
        }
    }
}
