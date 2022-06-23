
using MediatR;
using TEST.Application.SeedWork.Interfaces;
using TEST.Domain.ValueObjects;

namespace TEST.Application.Requests
{
    public class UpdateRequestsRequestHandler : AsyncRequestHandler<UpdateRequestsRequest>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateRequestsRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(UpdateRequestsRequest request, CancellationToken cancellationToken)
        {
            var permission = new Permission(
                request.Id,
                request.Name,
                request.LastName,
                request.PermissionTypeId,
                request.Date
               
            );

            _applicationDbContext.Permissions.Update(permission);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
