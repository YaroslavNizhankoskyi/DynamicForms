namespace Domain
{
    public abstract class Question : Entity
    {
        public Guid FormId { get; set; }
        public int Position { get; set; }
        public Guid ConfigId { get; set; }
        public bool IsRequired { get; set; }
        public Form Form { get; set; }
    }

    public class InputQuestion : Question
    {
        public InputType InputType { get; set; }

        public ICollection<InputAnswer> InputAnswers { get; set; }
    }

    public class SelectQuestion : Question
    {
        public SelectType SelectType { get; set; }
        public string Options { get; set; }
        public ICollection<SelectAnswer> SelectAnswers { get; set; }
    }

    public enum InputType
    {
        Text,
        Number,
        Date,
        File
    }

    public enum SelectType
    {
        Multiple,
        Single
    }
}
