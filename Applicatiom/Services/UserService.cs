﻿using Applicatiom.Interfaces.IRepositories;
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
            await _userRepository.Add(user);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}