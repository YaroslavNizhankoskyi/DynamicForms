namespace Domain
{
    public abstract class Answer : Entity
    {
        public Guid FormSubmitId { get; set; }
        public string Data { get; set; }
        public FormSubmit FormSubmit { get; set; }

    }

    public class InputAnswer : Answer
    {
        public Guid InputQuestionId { get; set; }
        public InputQuestion InputQuestion { get; set; }
    }

    public class SelectAnswer : Answer
    {
        public Guid SelectQuestionId { get; set; }
        public SelectQuestion SelectQuestion { get; set; }
    }
}
