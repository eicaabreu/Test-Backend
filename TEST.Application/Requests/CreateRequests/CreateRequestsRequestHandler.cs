using MediatR;
using TEST.Application.SeedWork.Interfaces;
using TEST.Domain.ValueObjects;

namespace TEST.Application.Requests
{
    public class CreateRequestsRequestHandler : AsyncRequestHandler<CreateRequestsRequest>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateRequestsRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreateRequestsRequest request, CancellationToken cancellationToken)
        {
            var permission = new Permission(
                request.Name,
                request.LastName,
                request.PermissionTypeId,
                request.Date
               
            );

            await _applicationDbContext.Permissions.AddAsync(permission, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
