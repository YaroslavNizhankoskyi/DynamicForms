namespace Domain
{
    public class PrivateFormAccessor : Entity
    {
        public Guid FormId { get; set; }

        public Guid AccessorId { get; set; }

        public DomainUser Accessor { get; set; }
        public Form Form { get; set; }
    }
}
