using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.Configurations
{
    public class AnswerConfiguration : EntityConfiguration<Answer>
    {
        public override void Configure(EntityTypeBuilder<Answer> builder)
        {

            builder.Property(x => x.Data)
                .IsRequired()
                .HasMaxLength(50_000);

            base.Configure(builder);
        }
    }
}
