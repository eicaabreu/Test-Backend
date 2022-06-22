using NUnit.Framework;
using TEST.Api.Controllers;

namespace TEST.Test
{
    public class Tests
    {
        private RequestsController _requests;

        [SetUp]
        public void Setup()
        {
            _requests = new RequestsController();
        }

        [Test]
        public void Test1()
        {
            var result = _requests.GetRequestById(1);

            Assert.(result, "1 should not be prime");

            Assert.Pass();
        }
    }
}