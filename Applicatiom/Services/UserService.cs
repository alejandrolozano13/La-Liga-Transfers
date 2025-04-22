using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public async Task Add(User user)
        {
            var emailIsAlreadyExists = await _userRepository.IsEmailTaken(user.Email);
            if (emailIsAlreadyExists) throw new Exception("O email já foi cadastrado.");
            await _userRepository.Add(user);
        }

        public async Task Delete(string id)
        {
            await _userRepository.Delete(id);
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, User user)
        {
            await _userRepository.Update(id, user);
        }
    }
}