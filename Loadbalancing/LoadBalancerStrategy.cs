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

       
        public List<string> services;
        public string API = "http://localhost:8071/prime/prime/";
        public string API1 = "http://localhost:8072/prime/prime/";
        public string API2 = "http://localhost:8073/prime/prime/";
        public int apirobinhood = 0;
        public LoadBalancerStrategy() 
        {
            

            services.Add(API);
            services.Add(API1);
            services.Add(API2);
        }

        public string NextService(List<string> services)
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
            else if(apirobinhood == 2)
            {
                apirobinhood++;
                return services[2];
            }
            
            
            throw new NotImplementedException();
        }
    }
}

