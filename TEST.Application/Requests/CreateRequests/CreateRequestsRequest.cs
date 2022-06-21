using MediatR;

namespace TEST.Application.Requests
{
    public record CreateRequestsRequest(
    string Name,
    string LastName,
    int PermissionTypeId,
    string Date
    ) : IRequest;
}
