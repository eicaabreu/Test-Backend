using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Domain.ValueObjects;

namespace TEST.Infrastructure.Database.EntityConfigurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permissions_");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.PermissionTypeId).HasColumnName("permission_type_id");
            builder.Property(x => x.Date).HasColumnName("date");

            builder.HasOne(d => d.PermissionType)
             .WithMany(d => d.Permission)
             .HasForeignKey(d => d.PermissionTypeId);
        }
    }
}
