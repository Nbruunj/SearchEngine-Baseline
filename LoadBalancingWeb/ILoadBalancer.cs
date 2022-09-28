using LoadBalancingWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancingWeb
{
    public interface ILoadBalancer
    {
        public List<Service> GetAllServices();
        public Service AddService(Service service);
        public Service RemoveService(Service service);
        public ILoadBalancerStrategy GetActiveStrategy();
        public void SetActiveStrategy(ILoadBalancerStrategy strategy);
        public Service NextService(List<Service> services);
    }
}
