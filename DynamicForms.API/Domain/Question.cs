namespace Domain
{
    public abstract class Question : Entity
    {
        public Guid FormId { get; set; }
        public string Text { get; set; }
        public bool IsRequired { get; set; }
        public int Position { get; set; }
        public Form Form { get; set; }
    }

    public class InputQuestion : Question
    {
        public InputType Type { get; set; }

        public ICollection<InputAnswer> InputAnswers { get; set; }
    }

    public class SelectQuestion : Question
    {
        public bool IsMultiple { get; set; }

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
}
