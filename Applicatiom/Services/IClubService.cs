using Domain.Entities;

namespace Applicatiom.Services
{
    public interface IClubService
    {
        Task<List<Club>> GetAll();
        Task<Club> GetById(string id);
        Task Add(Club club);
        Task Remove(string id);
    }
}