namespace Application.Models.Dto
{
    public record InputDto
    {
        public int Position { get; init; }
        public string Text { get; init; }
        public bool IsRequired { get; init; }
        public string Type { get; init; }
    }
}
