using Domain.Entities;

namespace Applicatiom.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<User> GetById(string id);
        Task<User> GetByEmail(string email);
        Task Add(User usuario);
    }
}