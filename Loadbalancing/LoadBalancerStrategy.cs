using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadbalancing
{
    public class LoadBalancerStrategy : ILoadBalancerStrategy
    {
        public List<string> services;
        public string API = "http://localhost:8071/prime/prime/";
        public string API1 = "http://localhost:8071/prime/prime/";
        public string API2 = "http://localhost:8071/prime/prime/";
        public LoadBalancerStrategy() 
        {
            services.Add(API);
            services.Add(API1);
            services.Add(API2);
        }

        public string NextService(List<string> services)
        {
            
            throw new NotImplementedException();
        }
    }
}

