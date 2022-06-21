using MediatR;

namespace TEST.Application.Requests
{
    public record GetRequestRequest
    (int Id) : IRequest<GetRequestDto>;
}
