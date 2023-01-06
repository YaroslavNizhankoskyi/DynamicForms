using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDomainDbContext
    {
        public DbSet<InputAnswer> InputAnswers { get; set; }
        public DbSet<SelectAnswer> SelectAnswers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormSubmit> FormSubmits { get; set; }
        public DbSet<InputQuestion> InputQuestions { get; set; }
        public DbSet<SelectQuestion> SelectQuestions { get; set; }
        public DbSet<DomainUser> DomainUsers { get; set; }
        public DbSet<PrivateFormAccessor> PrivateFormAccessors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
