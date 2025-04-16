using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(string id);
        Task<User> GetByEmail(string email);
        Task Add(User usuario);
    }
}