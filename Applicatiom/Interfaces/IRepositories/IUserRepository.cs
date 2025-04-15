using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<User> GetByEmail(string email);
        Task Add(User usuario);
    }
}