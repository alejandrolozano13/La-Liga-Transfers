using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class UserService : IUserService
    {
        public Task Add(User user)
        {
            throw new NotImplementedException();
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