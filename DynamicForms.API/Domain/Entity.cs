using Domain.Interfaces;

namespace Domain
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
