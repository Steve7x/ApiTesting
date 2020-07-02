using System;
using System.Net.Http;
using NUnit.Framework;
using TestClasses;
using System.Net;

namespace ApiTesting
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase]
        public void TestBearerToken()
        {
            TestMethods testBearerToken = new TestMethods();
            var sut = testBearerToken.GetBearerToken();
            Assert.AreEqual(175, sut.Length);
        }

        [TestCase]
        public void TestStatusCodeOfBearerToken()
        {
            TestMethods testReturningStatusCode = new TestMethods();
            var sut = testReturningStatusCode.ReturningStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, sut);
        }

        [TestCase]
        public void TestGetAgent()
        {
            TestMethods testGetAgent = new TestMethods();
            var sut = testGetAgent.GetAgent();
            Assert.AreEqual("Edward", sut.tempArray[1].FirstName);
        }
    }
}
