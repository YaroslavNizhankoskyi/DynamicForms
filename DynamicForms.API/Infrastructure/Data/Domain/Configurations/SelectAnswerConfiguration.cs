using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class SelectAnswerConfiguration : IEntityTypeConfiguration<SelectAnswer>
    {
        public void Configure(EntityTypeBuilder<SelectAnswer> builder)
        {
            builder.HasOne(x => x.FormSubmit)
                .WithMany(x => x.SelectAnswers)
                .HasForeignKey(x => x.FormSubmitId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.SelectQuestion)
                .WithMany(x => x.SelectAnswers)
                .HasForeignKey(x => x.SelectQuestionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasBaseType<Answer>();
        }
    }
}
