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
            using(ServiceHost host = new ServiceHost(typeof(Comunication.ImplementationServices)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Server is up...");
                    Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error al iniciar el servidor");
                }

            }
            
        }
    }
}
