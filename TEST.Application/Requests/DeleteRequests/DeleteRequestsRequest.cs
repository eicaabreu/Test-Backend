using MediatR;

namespace TEST.Application.Requests
{
    public record DeleteRequestsRequest
    (int Id) : IRequest;
}
