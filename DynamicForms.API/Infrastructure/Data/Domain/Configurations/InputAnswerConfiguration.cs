using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class InputAnswerConfiguration : IEntityTypeConfiguration<InputAnswer>
    {
        public void Configure(EntityTypeBuilder<InputAnswer> builder)
        {
            builder.HasOne(x => x.FormSubmit)
                .WithMany(x => x.InputAnswers)
                .HasForeignKey(x => x.FormSubmitId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.InputQuestion)
                .WithMany(x => x.InputAnswers)
                .HasForeignKey(x => x.InputQuestionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasBaseType<Answer>();
        }
    }
}
