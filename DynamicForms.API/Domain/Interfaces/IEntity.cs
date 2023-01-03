namespace Domain.Interfaces
{
    public interface IEntity : ISoftDeletable
    {
        public Guid Id { get; set; }
    }
}
