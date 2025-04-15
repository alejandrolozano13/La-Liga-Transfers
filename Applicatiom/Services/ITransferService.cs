using Applicatiom.DTOs;
using Domain.Entities;

namespace Applicatiom.Services
{
    public interface ITransferService
    {
        Task CreateTransfer(CreateTransferRequest request);
        Task<List<Transfer>> GetTransfers();
    }
}