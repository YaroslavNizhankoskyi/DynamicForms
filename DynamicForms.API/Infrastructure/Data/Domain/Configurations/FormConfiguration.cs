using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeleteBehavior = Microsoft.EntityFrameworkCore.DeleteBehavior;

namespace Infrastructure.Data.Domain.Configurations
{
    public class FormConfiguration : EntityConfiguration<Form>
    {
        public override void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(x => x.FormSubmits)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.InputQuestions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SelectQuestions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.CreatedForms)
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Domain)
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
