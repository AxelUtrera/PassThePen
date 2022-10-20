using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassThePenServer
{
    internal class Host
    {
        static void Main(string[] args)
        {
            Class1 object1 = new Class1();
            Console.WriteLine(object1.insertDataTest());
            Console.WriteLine("Server is up...");
            Console.ReadLine();

            
        }
    }
}
