namespace Application.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserEmail();
        Guid GetUserId();
        string GetRole();
    }
}
