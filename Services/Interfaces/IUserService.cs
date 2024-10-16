﻿using UserModel = ApiGap.Models.User;

namespace ApiGap.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel?> GetById(string id);
        Task<UserModel> Create(UserModel user);
        Task<UserModel> Update(UserModel user, string id);
        Task<bool> Delete(string id);
    }
}
