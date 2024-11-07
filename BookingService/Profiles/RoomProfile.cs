using AutoMapper;
using BookingService.DTOs.RoomDTOs;
using BookingService.Models;

namespace BookingService.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            // Source -> Target mappings
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomReadDto, RoomPublishedDto>();
        }
    }
}
