using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class PrivateFormAccessorConfiguration : EntityConfiguration<PrivateFormAccessor>
    {
        public override void Configure(EntityTypeBuilder<PrivateFormAccessor> builder)
        {
            builder.HasOne(x => x.Form)
                .WithMany(x => x.Accessors)
                .HasForeignKey(x => x.FormId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.Accessor)
                .WithMany(x => x.AccessedPrivateForms)
                .HasForeignKey(x => x.AccessorId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
