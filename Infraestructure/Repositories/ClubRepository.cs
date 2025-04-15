using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Repositories
{
    public class ClubRepository : IClubRepository
    {
        public Task<Club> Add(Club club)
        {
            throw new NotImplementedException();
        }

        public Task<Club> Delete(string id)
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

        public Task<Club> Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}