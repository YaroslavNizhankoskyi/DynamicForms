namespace Application.Models.Dto
{
    public record SelectDto : QuestionDto
    {
        public bool IsRequired { get; init; }
        public List<string> Options { get; init; }
        public bool IsMultiple { get; init; }
    }
}
