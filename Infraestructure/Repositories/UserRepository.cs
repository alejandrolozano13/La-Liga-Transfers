﻿using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;
using MongoDB.Driver;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        private const string CollectionName = "Users";

        public UserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>(CollectionName);
        }

        public async Task<List<User>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task Add(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _collection.InsertOneAsync(user);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _collection.Find(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException("Usuário não encontrado");
        }
    }
}