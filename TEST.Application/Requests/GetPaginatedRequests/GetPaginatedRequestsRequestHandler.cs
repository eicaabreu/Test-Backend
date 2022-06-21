using MediatR;
using TEST.Application.SeedWork.Extensions;
using TEST.Application.SeedWork.Interfaces;
using System.Linq.Expressions;
using TEST.Application.SeedWork.Models;
using TEST.Domain.ValueObjects;

namespace TEST.Application.Requests
{
    internal class GetPaginatedRequestsRequestHandler : IRequestHandler<GetPaginatedRequestsRequest, PaginatedList<Permission>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetPaginatedRequestsRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<PaginatedList<Permission>> Handle(GetPaginatedRequestsRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Permission, bool>> predicate = d => true;
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();
                predicate = d => d.Name.Contains(search);
            }

            var response = await _applicationDbContext.Permissions
                .Where(predicate)
                .OrderBy(d => d.Name)
                .PaginatedListAsync(request);

            return response;
        }
    }
}
