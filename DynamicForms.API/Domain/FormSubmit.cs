namespace Domain
{
    public class FormSubmit : Entity
    {
        public Guid FormId { get; set; }
        public Guid UserId { get; set; }
        public DomainUser User { get; set; }
        public Form Form { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        public ICollection<InputAnswer> InputAnswers { get; set; }
        public ICollection<SelectAnswer> SelectAnswers { get; set; }

    }
}
