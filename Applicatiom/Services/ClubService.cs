using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class ClubService : IClubService
    {
        public Task Add(Club club)
        {
            throw new NotImplementedException();
        }

        public Task<List<Club>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Club> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}