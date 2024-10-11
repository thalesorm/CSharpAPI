using UserModel = ApiGap.Models.User;

namespace ApiGap.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(string id);
        Task<UserModel> Create(UserModel user);
        Task<UserModel> Update(UserModel user, string id);
        Task<bool> Delete(string id);

        Task<UserModel?> GetByEmail(string email); // procurar uma forma melhor de fazer isso ou separar o arquivo
    }
}
