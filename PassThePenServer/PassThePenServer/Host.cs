using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PassThePenServer
{
    internal static class Host
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(Comunication.ImplementationServices)))
            {   
                    host.Open();
                    Console.WriteLine("The server is already :D");
                    Console.ReadLine();
            }
            
        }
    }
}
