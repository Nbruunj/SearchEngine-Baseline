using RoundRobin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadbalancing
{
    public class LoadBalancerStrategy : ILoadBalancerStrategy
    {


        public static string API = "http://localhost:8071/prime/prime/";
        public static string API1 = "http://localhost:8072/prime/prime/";
        public static string API2 = "http://localhost:8073/prime/prime/";
        public List<string> services = new List<string>
            { API, API1, API2 };
        public int apirobinhood = 0;
        public LoadBalancerStrategy() 
        {
          
        }

        public string NextService()
        {
            if(apirobinhood == 3)
            {
                 apirobinhood = 0;
            }
            if (apirobinhood == 0)
            {
                apirobinhood++;
                return services[0];
            }
            else if(apirobinhood == 1)
            {
                apirobinhood++;
                return services[1];
            }
            else
            {
                apirobinhood++;
                return services[2];
            }

        }
    }
}

