using MediatR;
using Microsoft.EntityFrameworkCore;
using TEST.Application.SeedWork.Interfaces;

namespace TEST.Application.Requests
{
    internal class GetRequestRequestHandler : IRequestHandler<GetRequestRequest, GetRequestDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetRequestRequestHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<GetRequestDto> Handle(GetRequestRequest request, CancellationToken cancellationToken)
        {
            var response = await _applicationDbContext.Permissions
                .Select(d => new GetRequestDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    LastName = d.LastName,
                    PermissionTypeId = d.PermissionTypeId,
                    Date = d.Date
                   
                })
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return response;
        }

    }
}
