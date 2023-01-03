using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class SelectQuiestionConfiguration : IEntityTypeConfiguration<SelectQuestion>
    {
        public void Configure(EntityTypeBuilder<SelectQuestion> builder)
        {
            builder.HasOne(x => x.Form)
                .WithMany(x => x.SelectQuestions)
                .HasForeignKey(x => x.FormId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.SelectAnswers)
                .WithOne(x => x.SelectQuestion)
                .HasForeignKey(x => x.SelectQuestionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.Property(x => x.IsMultiple)
                .IsRequired();

            builder.Property(x => x.Options)
                .IsRequired()
                .HasMaxLength(50_000);

            builder.HasBaseType<Question>();
        }
    }
}
