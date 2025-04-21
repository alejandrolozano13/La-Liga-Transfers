using Applicatiom.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Applicatiom.Mappings
{
    public class PlayerProfile: Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerDto>();
        }
    }
}