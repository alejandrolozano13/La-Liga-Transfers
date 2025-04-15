using Applicatiom.DTOs;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class TransferService : ITransferService
    {
        public Task CreateTransfer(CreateTransferRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transfer>> GetTransfers()
        {
            throw new NotImplementedException();
        }
    }
}