using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Domain
{
    internal class DomainDbContext : DbContext, IDomainDbContext
    {
        public DbSet<InputAnswer> InputAnswers { get; set; }
        public DbSet<SelectAnswer> SelectAnswers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormSubmit> FormSubmits { get; set; }
        public DbSet<InputQuestion> InputQuestions { get; set; }
        public DbSet<SelectQuestion> SelectQuestions { get; set; }
        public DbSet<DomainUser> DomainUsers { get; set; }
        public DbSet<PrivateFormAccessor> PrivateFormAccessors { get; set; }

        public DomainDbContext()
        {

        }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("domain");

            //pluralize the name
            modelBuilder.Entity<PrivateFormAccessor>().ToTable("PrivateFormAccessors");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var domainAssembly = typeof(DomainDbContext).Assembly;
            var softDeletableEntities = domainAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Entity))
                && !type.IsSubclassOf(typeof(Answer))
                && !type.IsSubclassOf(typeof(Question)));

            foreach (var entityType in softDeletableEntities)
            {
                typeof(DomainDbContext)
                .GetMethod("MakeSoftDeletable")
                ?.MakeGenericMethod(entityType)
                .Invoke(this, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);
        }

        public void MakeSoftDeletable<T>(ModelBuilder modelBuilder) where T : class, ISoftDeletable
        {
            modelBuilder.Entity<T>()
                .HasQueryFilter(p => !p.IsDeleted)
                .Property(e => e.IsDeleted);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        break;

                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
