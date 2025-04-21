using Applicatiom.DTOs;
using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IClubRepository _clubRepository;

        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IClubRepository clubRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public Task<List<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(PlayerDto playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            await _playerRepository.Add(player);

            var club = await _clubRepository.GetById(player.ClubId);

            if (club is null) return;

            club.Players.Add(player.Id);
            await _clubRepository.Update(club);
        }

        public async Task Update(string id, Player player)
        {
            if (string.IsNullOrEmpty(player.Id)) throw new Exception("Informe o Id do jogador.");
            
            player.Id = id;
            await _playerRepository.Update(player);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }


    }
}