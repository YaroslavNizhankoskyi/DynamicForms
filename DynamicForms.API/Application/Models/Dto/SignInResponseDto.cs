namespace Application.Models.Dto
{
    public record SignInResponseDto
    (
        string Email,
        Guid Id,
        string UserName,
        string Role,
        string Token
    );
}
