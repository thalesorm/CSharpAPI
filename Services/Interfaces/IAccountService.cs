namespace ApiGap.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(string email, string password);
    }
}
