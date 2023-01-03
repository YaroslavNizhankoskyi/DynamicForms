using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class InputQuestionConfiguration : IEntityTypeConfiguration<InputQuestion>
    {
        public void Configure(EntityTypeBuilder<InputQuestion> builder)
        {
            builder.HasOne(x => x.Form)
                .WithMany(x => x.InputQuestions)
                .HasForeignKey(x => x.FormId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasMany(x => x.InputAnswers)
                .WithOne(x => x.InputQuestion)
                .HasForeignKey(x => x.InputQuestionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasBaseType<Question>();
        }
    }
}
