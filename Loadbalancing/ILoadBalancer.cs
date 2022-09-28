using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadbalancing
{
    public interface ILoadBalancer
    {
        public List<string> GetAllServices();
        public int AddService(string url);
        public int RemoveService(int id);
        public ILoadBalancerStrategy GetActiveStrategy();
        public void SetActiveStrategy(ILoadBalancerStrategy strategy);
        public string NextService();
    }
}
