using MediatR;
using TEST.Application.SeedWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Application.Requests
{
    public class DeleteRequestsRequestHandler : AsyncRequestHandler<DeleteRequestsRequest>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteRequestsRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(DeleteRequestsRequest request, CancellationToken cancellationToken)
        {
            var permission = await _applicationDbContext.Permissions.FindAsync(request.Id);
            _applicationDbContext.Permissions.Remove(permission);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
    
}
