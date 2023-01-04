namespace Application.Models.Dto
{
    public record RegisterUserDto
    (
        string UserName,
        string Email,
        string Password
    );
}
