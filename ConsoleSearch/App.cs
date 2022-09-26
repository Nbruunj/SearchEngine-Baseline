using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ConsoleSearch
{
    public class App
    {
        public string API = "http://localhost:8071/search/search/";

        public void Start()
        {
            Console.WriteLine("press 1 to Console Search");
            Console.WriteLine("press 2 prime number to check for primenumbers");
            var select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    var task = Run();
                    task.Wait();
                    break;
                case "2":
                    primeNumber();
                    break;
            }
            
            
        }

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
        public void primeNumber()
        {
            Console.WriteLine("1: do you wont to check a single prime number");
            Console.WriteLine("2: do you wont to check multiple prime number");
            var select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    checksingleprimenumber();
                    break;
                case "2":
                    checkmultipleprimenumber();
                    break;
            }
          
        }

        public void checksingleprimenumber()
        {
            int n, i, m = 0, flag = 0;
            Console.Write("Enter the Number to check Prime: ");
            n = int.Parse(Console.ReadLine());
            m = n / 2;
            for (i = 2; i <= m; i++)
            {
                if (n % i == 0)
                {
                    Console.Write("Number is not Prime.");
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
                Console.Write("Number is Prime.");
        }

        public void checkmultipleprimenumber()
        { 
         
            Console.Write("enter the first number");
            var firstnumber = long.Parse(Console.ReadLine());
            Console.Write("enter the first number");
            var secondnumber = long.Parse(Console.ReadLine());

            getPrimeNumber(firstnumber, secondnumber);

        }
        public static List<long> getPrimeNumber(long first, long last)
        {
            List<long> list = new List<long>();
            Console.WriteLine("Sequential calculation started...");

            for (long i = first; i <= last; i++)
            {
                bool isPrime = true;
                if (i > 1)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime == true)
                    {
                        Console.WriteLine("the is a prime number " + i);
                        list.Add(i);
                    }

                }
            }
            Console.WriteLine("Found: " + list.Count() + " prime numbers.");
            return list;
        }

    }
}
