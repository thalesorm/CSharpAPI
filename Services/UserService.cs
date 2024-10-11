using ApiGap.Repository;
using ApiGap.Repository.Interfaces;
using ApiGap.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using UserModel = ApiGap.Models.User;

namespace ApiGap.Services

{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                throw new Exception("Nenhum usuário encontrado.");
            }
            return users;
        }

        public async Task<UserModel?> GetById(string id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return user;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            if (!isValid)
            {
                var errors = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
                throw new ValidationException("Usuário inválido: {errors}");
            }

            return await _userRepository.Create(user);
        }

        public async Task<UserModel> Update(UserModel user, string id)
        {
            var existingUser = await _userRepository.GetById(id);
            if (existingUser == null)
            {
                throw new Exception($"Usuário com ID {id} não encontrado. Não é possível atualizar.");
            }

            existingUser.Name = user.Name;
            existingUser.Job = user.Job;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Avatar = user.Avatar;
            existingUser.Status = user.Status;
            existingUser.Role = user.Role;
            existingUser.IdUnity = user.IdUnity;
            existingUser.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.Update(existingUser, id);
        }

        public async Task<bool> Delete(string id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception($"Usuário com ID {id} não encontrado. Não é possível deletar.");
            }

            return await _userRepository.Delete(id);
        }
    }

}
