using Domain.Entities;

namespace Applicatiom.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(string id);
        Task<User> GetByEmail(string email);
        Task Add(User user);
        Task Update(User user);
        Task Delete(string id);
    }
}