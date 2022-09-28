using Microsoft.AspNetCore.Mvc;

namespace LoadBalancingWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadBalancerController : ControllerBase
    {
        static LoadBalancerStrategy strategy = new LoadBalancerStrategy();

        public List<string> _services = new List<string>();
       
        LoadBalancer _LoadBalancer = new LoadBalancer(strategy);


        public LoadBalancerController()
        {
            

        }
        [HttpGet("[controller]/GetNextService/{service}")]
        public ActionResult<Service> GetNextService()
        {

            return _LoadBalancer.NextService(_LoadBalancer.GetAllServices());
        }

        [Route("[controller]/RemoveService")]
        [HttpDelete]
        public ActionResult<Service> RemoveService(string url)
        {
            var serviceToRemove = _LoadBalancer.GetAllServices().Find(x => x.UrlName == url);
            var removedService = _LoadBalancer.RemoveService(serviceToRemove);
            return removedService;
        }

        [Route("[controller]/AddService")]
        [HttpPost]
        public ActionResult<Service> AddService(Service service)
        {
            var addedService = _LoadBalancer.AddService(service);
            return addedService;
        }

        [Route("[controller]/GetAllServices")]
        [HttpGet]
        public ActionResult<List<Service>> GetAllServices() 
        {
            var services = _LoadBalancer.GetAllServices();
            return services;
        }


    }

    public class Service
    {
        public Guid Id { get; set; }
        public string UrlName{ get; set; }

    }
}
