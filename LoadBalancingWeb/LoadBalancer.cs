using LoadBalancingWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancingWeb
{
    public class LoadBalancer : ILoadBalancer
    {
        private ILoadBalancerStrategy _strategy;

        public Service API = new Service { Id = Guid.NewGuid(), UrlName = "http://localhost:8071/prime/prime/" };
        public Service API1 = new Service { Id = Guid.NewGuid(), UrlName = "http://localhost:8072/prime/prime/" };
        public Service API2 = new Service { Id = Guid.NewGuid(), UrlName = "http://localhost:8073/prime/prime/" };

        List<Service> _services = new List<Service>();
        

        public LoadBalancer(ILoadBalancerStrategy strategy)
        {
            _strategy = strategy;
            if (_services.Count == 0)
            {
                this.AddService(API);
                this.AddService(API1);
                this.AddService(API2);
            }
        }

        public List<Service> GetAllServices()
        {
            return _services;
        }

        public Service AddService(Service service)
        {
            _services.Add(service);
            return service;
        }

        public Service RemoveService(Service service)
        {
            _services.RemoveAt(_services.FindIndex(x => x.Id == service.Id));
            return service;
        }

        public ILoadBalancerStrategy GetActiveStrategy()
        {
            return _strategy;
        }

        public void SetActiveStrategy(ILoadBalancerStrategy strategy)
        {
            _strategy = strategy;
        }

        public Service NextService(List<Service> services)
        {
            return _strategy.NextService(services);
        }
    }
}
