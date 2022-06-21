using MediatR;
using TEST.Application.SeedWork.Models;
using TEST.Domain.ValueObjects;

namespace TEST.Application.Requests
{
    public record GetPaginatedRequestsRequest
    () : BasePaginatedRequest, IRequest<PaginatedList<Permission>>;
}
