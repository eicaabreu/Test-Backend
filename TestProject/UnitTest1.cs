using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TEST.Api.Controllers;
using TEST.Application.Requests;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly RequestsController _controller;
        private readonly CreateRequestsRequest _service;


        public UnitTest1()
        {
            _controller = new RequestsController();
            string Name = string.Empty;
            string LastName = string.Empty;
            int PermissionTypeId = 0;
            string Date = string.Empty;
            _service =  new CreateRequestsRequest(Name,LastName,PermissionTypeId,Date);



        }
        [Fact]
        public void GetVerifyGetRequestByIdIsExactlyType()
        {

            var okResult = _controller.GetRequestById(1);
          
            Assert.IsType<Task<IActionResult>>(okResult);
            Assert.NotNull(okResult);
        }

        [Fact]
        public void GetVerifyGetAllRequestsIsNotNull()
        {
            
            var okResult = _controller.GetRequests();
            Assert.NotNull(okResult);
        }


        [Fact]
        public void CreateVerifyReturnOk()
        {
            var okResult = _controller.CreateRequest(_service).Status.ToString();
            Assert.Equal("OK", okResult);
        }

        [Fact]
        public void DeleteVerifyReturnOk()
        {
            var okResult = _controller.DeleteRequest(1).Status.ToString();
            Assert.Equal("OK", okResult);
        }


    }
}