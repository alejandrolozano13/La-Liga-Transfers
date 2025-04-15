using Applicatiom.DTOs;
using Domain.Entities;

namespace Applicatiom.Interfaces.IServices
{
    public interface ITransferService
    {
        Task CreateTransfer(CreateTransferRequest request);
        Task<List<Transfer>> GetTransfers();
    }
}