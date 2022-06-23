using System.Reflection;
using System.Threading.Tasks;
using TEST.Application.Requests;
using TEST.Application.SeedWork.Interfaces;
using Xunit;

namespace TestProject
{
    public class RequestTest
    {
        private readonly CreateRequestsRequestHandler _CreateRequest;
        private readonly DeleteRequestsRequestHandler _DeleteRequest;
        private readonly UpdateRequestsRequestHandler _UpdateRequest;
        private readonly IApplicationDbContext _applicationDbContext;

        public RequestTest()
        {
          _CreateRequest = new CreateRequestsRequestHandler(_applicationDbContext);
          _DeleteRequest = new DeleteRequestsRequestHandler(_applicationDbContext);
          _UpdateRequest = new UpdateRequestsRequestHandler(_applicationDbContext);



        }
        [Fact]
        public void GetVerifyCreateRequestIsNotNull()
        {

            var result = _CreateRequest.Equals(_applicationDbContext);
            Assert.NotNull(result);

        }
        [Fact]
        public void GetVerifyDeleteRequestIsNotNull()
        {

            var result = _DeleteRequest.Equals(_applicationDbContext);
            Assert.NotNull(result);

        }

        [Fact]
        public void GetVerifyUpdateRequestIsNotNull()
        {

            var result = _UpdateRequest.Equals(_applicationDbContext);
            Assert.NotNull(result);

        }



    }
}