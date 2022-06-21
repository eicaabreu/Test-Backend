using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEST.Application.SeedWork.Interfaces;

namespace TEST.Application.Requests
{
    internal class DeleteRequestsRequestValidator : AbstractValidator<DeleteRequestsRequest>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteRequestsRequestValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("El identificador es requerido")
                .MustAsync(ExistrequestAsync).WithMessage("El identificador no pertenece a ninguna solicitud de permiso");
        }

        private async Task<bool> ExistrequestAsync(int id, CancellationToken cancellationToken)
        {
            var exist = await _applicationDbContext.Permissions.AnyAsync(d => d.Id == id, cancellationToken);
            return exist;
        }
    }
}
