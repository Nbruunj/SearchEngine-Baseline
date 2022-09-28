using Microsoft.AspNetCore.Mvc;

namespace LoadBalancingWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadBalancerController : ControllerBase
    {
        static LoadBalancerStrategy strategy = new LoadBalancerStrategy();

        public List<string> _services = new List<string>();
        public static string API = "http://localhost:8071/prime/prime/";
        public static string API1 = "http://localhost:8072/prime/prime/";
        public static string API2 = "http://localhost:8073/prime/prime/";
        LoadBalancer _LoadBalancer = new LoadBalancer(strategy);


        public LoadBalancerController() 
        {
            
            _LoadBalancer.AddService(API);
            _LoadBalancer.AddService(API1);
            _LoadBalancer.AddService(API2);

        }
        [HttpGet("[controller]/GetNextService")]
        public ActionResult<string> GetNextService()
        {

            return _LoadBalancer.NextService();
        }

    }
}
