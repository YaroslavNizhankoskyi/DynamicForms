namespace Application.Models
{
    public record UserDetails(
        string Email,
        string Role,
        string Name,
        Guid AuthId,
        Guid DomainId
    );
}
