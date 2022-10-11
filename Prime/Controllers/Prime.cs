using Microsoft.AspNetCore.Mvc;

namespace Prime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Prime : ControllerBase
    {
        //public void primeNumber()
        //{
        //    Console.WriteLine("1: do you wont to check a single prime number");
        //    Console.WriteLine("2: do you wont to check multiple prime number");
        //    var select = Console.ReadLine();
        //    switch (select)
        //    {
        //        case "1":
        //            checksingleprimenumber();
        //            break;
        //        case "2":
        //            checkmultipleprimenumber();
        //            break;
        //    }

        //}
        [HttpGet("[controller]/CheckSinglePrimeNumber/{number}")]
        public ActionResult<bool> CheckSinglePrimeNumber(int number)
        {
            int n, i, m = 0, flag = 0;
            Console.Write("Enter the Number to check Prime: ");
            m = number / 2;
            for (i = 2; i <= m; i++)
            {
                if (number % i == 0)
                {
                    Console.Write("Number is not Prime.");
                    flag = 1;
                    return false;
                }
            }
            if (flag == 0)
                Console.Write("Number is Prime.");
            return true;
        }

        [HttpGet("[controller]/CheckMultiplePrimeNumbers/{number}/{number2}")]
        public ActionResult<List<long>> CheckMultiplePrimeNumbers(int number, int number2)
        {
            List<long> list = new List<long>();
            Console.WriteLine("Sequential calculation started...");

            for (long i = number; i <= number2; i++)
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
