namespace Application.Models.Dto
{
    public record SelectDto
    {
        public int Position { get; init; }
        public string Text { get; init; }
        public bool IsRequired { get; init; }
        public string Type { get; init; }
        public List<string> Options { get; init; }
        public bool IsMultiple { get; init; }
    }
}
