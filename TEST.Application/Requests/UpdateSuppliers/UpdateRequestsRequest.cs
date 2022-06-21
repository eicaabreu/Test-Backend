
using MediatR;

namespace TEST.Application.Requests
{
    public record UpdateRequestsRequest
    (
        int Id,
        string Name,
        string LastName,
        int PermissionTypeId,
        string Date
        
    ) : IRequest;
}
