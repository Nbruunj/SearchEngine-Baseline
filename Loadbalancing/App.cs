
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;



namespace Loadbalancing
{
    public class App
    {
        //public string API = "";


        public void Start()
        {
            Console.WriteLine("1: do you wont to check a single prime number");
            Console.WriteLine("2: do you wont to check multiple prime number");
            var select = Console.ReadLine();
            LoadBalancerStrategy strategy = new LoadBalancerStrategy();
            var test = strategy.NextService();
            Console.WriteLine(test);
            Start();



        }
    }
}
