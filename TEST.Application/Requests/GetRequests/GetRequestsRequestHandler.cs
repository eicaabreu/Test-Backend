using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Application.SeedWork.Interfaces;

namespace TEST.Application.Requests
{
    internal class GetRequestsRequestHandler : IRequestHandler<GetRequestsRequest, IEnumerable<GetRequestsDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetRequestsRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<GetRequestsDto>> Handle(GetRequestsRequest request, CancellationToken cancellationToken)
        {
            var permissionTypes = await _applicationDbContext.PermissionTypes
                .Select(d => new GetRequestsDto
                {
                    Id = d.Id,
                    Description = d.Description
                })
                .ToListAsync(cancellationToken);

            return permissionTypes;
        }
    }
}
