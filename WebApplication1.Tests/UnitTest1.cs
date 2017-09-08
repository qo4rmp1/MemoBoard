using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication1.Tests
{
    [TestClass]
    public class FirstUnitTest
    {
        [TestMethod]
        public void HelloWorld()
        {
            var actual = "Hello World";
            Assert.AreEqual("Hello World", actual);
        }
        
    }
}
