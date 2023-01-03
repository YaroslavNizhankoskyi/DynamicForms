using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    internal class DomainUserConfiguration : EntityConfiguration<DomainUser>
    {
        public override void Configure(EntityTypeBuilder<DomainUser> builder)
        {
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(x => x.CreatedForms)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasMany(x => x.FormSubmits)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasMany(x => x.AccessedPrivateForms)
                .WithOne(x => x.Accessor)
                .HasForeignKey(x => x.AccessorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
