


namespace Loadbalancing
{
    public class App
    {
        LoadBalancerStrategy strategy = new LoadBalancerStrategy();
        
        public List<string> _services = new List<string>();
        public static string API = "http://localhost:8071/prime/prime/";
        public static string API1 = "http://localhost:8072/prime/prime/";
        public static string API2 = "http://localhost:8073/prime/prime/";

        public void Start()
        {
            LoadBalancer LoadBalancer = new LoadBalancer(strategy);
            LoadBalancer.AddService(API);
            LoadBalancer.AddService(API1);
            LoadBalancer.AddService(API2);
            var select = Console.ReadLine();
            Console.WriteLine(LoadBalancer.NextService());
            Start();
            

        }
        
      

    }
}
