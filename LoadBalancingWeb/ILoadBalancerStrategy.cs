using LoadBalancingWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancingWeb
{
    public interface ILoadBalancerStrategy
    {
        public Service NextService(List<Service> services);
    }
}
