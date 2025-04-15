using Domain.Entities;

namespace Applicatiom.Interfaces
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAll();
        Task<Club> GetById(string id);
        Task<Club> Add (Club club);
        Task<Club> Update (Club club);
        Task<Club> Delete(string id);
    }
}