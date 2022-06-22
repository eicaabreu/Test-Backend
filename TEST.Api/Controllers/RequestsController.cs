using Microsoft.AspNetCore.Mvc;
using TEST.Application.Requests;

namespace TEST.Api.Controllers
{

    public class RequestsController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var request = new GetRequestsRequest();
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("paginated")]
        public async Task<IActionResult> GetPaginatedRequests(GetPaginatedRequestsRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestsRequest request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var request = new GetRequestRequest(id);
            var response = await Mediator.Send(request);
            if (response is null) return NotFound();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, UpdateRequestsRequest request)
        {
            if (id != request.Id) return BadRequest();

            await Mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = new DeleteRequestsRequest(id);
            await Mediator.Send(request);
            return NoContent();
        }

    }
}
