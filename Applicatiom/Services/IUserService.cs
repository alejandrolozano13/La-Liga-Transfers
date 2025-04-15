using Domain.Entities;

namespace Applicatiom.Services
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task Add (User user);
        Task Update (User user);
        Task Delete (string id);
    }
}