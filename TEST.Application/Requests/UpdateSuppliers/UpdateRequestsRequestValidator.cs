
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEST.Application.SeedWork.Interfaces;

namespace TEST.Application.Requests
{
    internal class UpdateRequestsRequestValidator : AbstractValidator<UpdateRequestsRequest>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateRequestsRequestValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es requerido");


            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("El apellido es requerido");

            RuleFor(x => x.Date)
             .NotEmpty().WithMessage("La fecha es requerida");


            RuleFor(x => x.PermissionTypeId)
                .MustAsync(CheckPermissionType).WithMessage("El identificador no pertenece a ningun tipo de permiso")
                .Unless(x => x.PermissionTypeId == 0);

        }
        private async Task<bool> CheckPermissionType(int id, CancellationToken cancellationToken)
        {
            var exist = await _applicationDbContext.PermissionTypes.AnyAsync(x => x.Id == id, cancellationToken);
            return exist;
        }
    }
}
