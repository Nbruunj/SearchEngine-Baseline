using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Numerics;


namespace primes
{
    [TestClass]
    public class primetest1
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.


        [TestMethod]
        public void isitprimenumber()
        {
            // Arrange
            string expected = "2 2 2 5 ";


            // Act
            string actual = primestest1.isprime(40);
            // Asset
            Assert.AreEqual(expected, actual);

        }
    }
}