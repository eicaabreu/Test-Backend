using Microsoft.EntityFrameworkCore;
using TEST.Domain.ValueObjects;

namespace TEST.Application.SeedWork.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Permission> Permissions { get; }
        DbSet<PermissionType> PermissionTypes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
