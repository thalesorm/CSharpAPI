using ApiGap.Data;
using ApiGap.Interfaces;
using UserModel = ApiGap.Models;

namespace ApiGap.Services

{
    public class UserService
    {
        private readonly GapApiDBContext _dbContext;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
