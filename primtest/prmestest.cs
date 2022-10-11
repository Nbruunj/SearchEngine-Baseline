using Microsoft.VisualStudio.TestTools.UnitTesting;
using primes;
using System;

namespace primtest
{
    [TestClass]
    public class prmestest
    {
       
            [TestMethod]
            public void isitprimenumber()
            {
                // Arrange
                string expected = "3";


                // Act
                string actual = primestest1.isprime(5);
                // Asset
                Assert.AreEqual(expected, actual);

            }
        
    }
}
