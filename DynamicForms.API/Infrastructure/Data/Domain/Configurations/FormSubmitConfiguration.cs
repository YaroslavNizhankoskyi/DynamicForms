using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class FormSubmitConfiguration : EntityConfiguration<FormSubmit>
    {
        public override void Configure(EntityTypeBuilder<FormSubmit> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.FormSubmits)
                .HasForeignKey(x => x.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.InputAnswers)
                .WithOne(x => x.FormSubmit)
                .HasForeignKey(x => x.FormSubmitId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.SelectAnswers)
                .WithOne(x => x.FormSubmit)
                .HasForeignKey(x => x.FormSubmitId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
