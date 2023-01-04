namespace Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(string userEmail);
    }
}
