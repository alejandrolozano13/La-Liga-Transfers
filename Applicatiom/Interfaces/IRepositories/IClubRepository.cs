using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAll();
        Task<Club> GetById(string id);
        Task Add(Club club);
        Task Update(Club club);
        Task Delete(string id);
    }
}