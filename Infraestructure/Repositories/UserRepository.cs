using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User usuario)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}