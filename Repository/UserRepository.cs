using ApiGap.Data;
using ApiGap.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserModel = ApiGap.Models.User;

namespace ApiGap.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GapApiDBContext _dbContext;
        public UserRepository(GapApiDBContext gapApiDBContext)
        {
            _dbContext = gapApiDBContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return  await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel?> GetById(string id)
        {
            UserModel? userById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userById;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, string id)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(string id)
        {
            UserModel? userToUpdate = await GetById(id);

            if (userToUpdate == null)
            {
                return false;
            }

            _dbContext.Users.Remove(userToUpdate);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
