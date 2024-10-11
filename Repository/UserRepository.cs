using ApiGap.Data;
using ApiGap.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserModel = ApiGap.Models.User;

namespace ApiGap.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiGapDBContext _dbContext;
        public UserRepository(ApiGapDBContext gapApiDBContext)
        {
            _dbContext = gapApiDBContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                return  await _dbContext.Users.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserModel?> GetById(string id)
        {
            UserModel? userById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userById;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            try
            {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new UserModel();
            }

            return user;
        }

        public async Task<UserModel> Update(UserModel user, string id)
        {
            _dbContext.Users.Update(user);
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
