﻿namespace ApiGap.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);
    }
}
