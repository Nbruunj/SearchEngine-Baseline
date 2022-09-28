using Loadbalancing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;



namespace ConsoleSearch
{
    public class App
    {
        public string API = "http://localhost:5215/LoadBalancer/LoadBalancer/";
        public void Start()
        {
            Console.WriteLine("1: do you wont to check a single prime number");
            Console.WriteLine("2: do you wont to check multiple prime number");

            var select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    var task = getstringprimenumber();
                    task.Wait();

                    break;
                case "2":
                    var task2 = getallprimesinbetween();
                    task2.Wait();
                    break;

            }
            Start();



        }

        public string GetDockerUrl() 
        {
            string url = string.Format(API + "GetNextService");
            string json = new WebClient().DownloadString(url);
            return json;
        }
        
         
            public async Task<string> getstringprimenumber()
            {

            Console.WriteLine(GetDockerUrl());
            Console.WriteLine("enter number here thx you");
            string input = Console.ReadLine() ?? string.Empty;
            string url = string.Format(GetDockerUrl() + "CheckSinglePrimeNumber/" + input);
            string json = await new WebClient().DownloadStringTaskAsync(url);
            var result = JsonConvert.DeserializeObject<string>(json);
            Console.WriteLine(result);
            return result;
        }

        public async Task<List<string>> getallprimesinbetween()
        {
            Console.Write(GetDockerUrl());
            Console.Write("enter the first number");
            string inputone = Console.ReadLine() ?? string.Empty;
            Console.Write("enter the Second number");
            string inputtwo = Console.ReadLine() ?? string.Empty;
            string url = string.Format(GetDockerUrl() + "CheckMultiplePrimeNumbers/" + inputone + "/" + inputtwo);
            string json = await new WebClient().DownloadStringTaskAsync(url);
            var result = JsonConvert.DeserializeObject<List<string>>(json);
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
            
            return result;

        }



            /*
            public async Task Run()
            {

                Console.WriteLine("Console Search");
                while (true)
                {
                    Console.WriteLine("enter search terms - q for quit");
                    string input = Console.ReadLine() ?? string.Empty;
                    if (input.Equals("q")) break;

                    var wordIds = new List<int>();
                    var searchTerms = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var t in searchTerms)
                    {
                        var id = GetIdOf(t);
                        if (id.Result != -1)
                        {
                            wordIds.Add(id.Result);
                        }
                        else
                        {
                            Console.WriteLine(t + " will be ignored");
                        }
                    }

                    DateTime start = DateTime.Now;

                    var docIds = await GetDocuments(wordIds);


                    // get details for the first 10             
                    var top10 = new List<int>();
                    foreach (var p in docIds.GetRange(0, Math.Min(10, docIds.Count)))
                    {
                        top10.Add(p.Key);
                    }

                    TimeSpan used = DateTime.Now - start;

                    int idx = 0;

                    var docDetails = await GetDocumentDetails(top10);

                    foreach (var doc in docDetails)
                    {
                        Console.WriteLine("" + (idx + 1) + ": " + doc + " -- contains " + docIds[idx].Value + " search terms");
                        idx++;

                    }
                    Console.WriteLine("Documents: " + docIds.Count + ". Time: " + used.TotalMilliseconds);

                }
            }

            public async Task<int> GetIdOf(string word)
            {
                string url = string.Format(API + "getidof/" + word);
                string json = await new WebClient().DownloadStringTaskAsync(url);
                var result = JsonConvert.DeserializeObject<int>(json);
                return result;
            }

            public async Task<List<KeyValuePair<int, int>>> GetDocuments(List<int> wordIds)
            {
                var wordIdList = string.Join("&wordIds=", wordIds.Select(w => w.ToString()));
                string url = string.Format(API + "getdocuments?wordIds=" + wordIdList);

                WebClient client = new WebClient();

                string json = await client.DownloadStringTaskAsync(url);
                var results = JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(json);

                return results;
            }

            public async Task<List<string>> GetDocumentDetails(List<int> docIds)
            {
                var docIdList = string.Join("&docIds=", docIds.Select(w => w.ToString()));
                string url = string.Format(API + "getdocumentdetails?docIds=" + docIdList);

                WebClient client = new WebClient();

                string json = await client.DownloadStringTaskAsync(url);
                var results = JsonConvert.DeserializeObject<List<string>>(json);

                return results;
            }
            */

        }
}
