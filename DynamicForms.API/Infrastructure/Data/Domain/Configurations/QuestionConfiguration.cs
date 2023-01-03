using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class QuestionConfiguration : EntityConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsRequired)
                .IsRequired();

            builder.Property(x => x.Position)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
