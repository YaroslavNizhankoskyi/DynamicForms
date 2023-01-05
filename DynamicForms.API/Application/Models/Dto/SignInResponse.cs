namespace Application.Models.Dto
{
    public record SignInResponse
    (
        string Email,
        Guid Id,
        string UserName,
        string Role,
        string Token
    );
}
