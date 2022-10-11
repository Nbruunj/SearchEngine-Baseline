using System;
using System.Collections.Generic;
using System.Text;

namespace primes
{
    public class primestest1
    {
        public static string isprime(int number)
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
                    
                }
            }
            if (flag == 0)
                Console.Write("Number is Prime.");
           
            return flag.ToString();
        }
    }
}
