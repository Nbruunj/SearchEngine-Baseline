using LoadBalancingWeb.Controllers;
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

        public Service NextService(List<Service> services)
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
            else if (services[2] != null)
            {
                apirobinhood++;
                return services[2];
            }
            else {
                //RETURN ERROR MESSAGE
                return services[0];
            }
            
            

        }
    }
}

