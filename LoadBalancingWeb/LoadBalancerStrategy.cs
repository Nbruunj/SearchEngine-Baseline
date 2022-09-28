using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancingWeb
{
    public class LoadBalancerStrategy : ILoadBalancerStrategy
    {


        
        public int apirobinhood = 0;
        public LoadBalancerStrategy() 
        {
          
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
            else
            {
                apirobinhood++;
                return services[2];
            }

        }
    }
}

