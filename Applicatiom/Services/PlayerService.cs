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

        public async Task<List<Player>> GetAll()
        {
            return await _playerRepository.GetAll();
        }

        public async Task<Player> GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new Exception("Informe o Id do jogador");
            return await _playerRepository.GetById(id);
        }

        public async Task<List<Player>> GetByClubId(string clubId)
        {
            if (string.IsNullOrEmpty(clubId)) throw new Exception("Informe o Id do jogador");
            return await _playerRepository.GetByClubId(clubId);
        }

        public async Task Add(PlayerDto playerDto)
        {
            if (playerDto is null) throw new Exception("Informe um jogador.");
            
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

        public async Task Delete(string id)
        {
            if(string.IsNullOrEmpty(id)) throw new Exception("Informe o Id do jogador.");

            var player = await GetById(id);
            await _playerRepository.Delete(id);
            
            var club = await _clubRepository.GetById(player.ClubId);
            club.Players.Remove(player.Id);
            await _clubRepository.Update(club);
        }

        public async Task RemovePlayerClubAfterDeleteClub(string clubId)
        {
            var players = await GetByClubId(clubId);

            foreach (var player in players)
            {
                player.ClubId = string.Empty;
                await _playerRepository.Update(player);
            }
        }
    }
}