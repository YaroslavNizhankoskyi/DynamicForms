namespace Domain
{
    public class Form : Entity
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public string Name { get; set; }
        public Visibility Visibility { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public Guid CreatorId { get; set; }
        public ICollection<InputQuestion> InputQuestions { get; set; }
        public ICollection<SelectQuestion> SelectQuestions { get; set; }
        public ICollection<FormSubmit> FormSubmits { get; set; }
        public ICollection<PrivateFormAccessor> Accessors { get; set; }
        public DomainUser Creator { get; set; }
    }

    public enum Visibility
    {
        Public,
        Private
    }
}
