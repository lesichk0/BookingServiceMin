using AutoMapper;
using BookingService.DTOs.GuestDTOs;
using BookingService.Models;

namespace BookingService.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            // Source -> Target mappings
            CreateMap<Guest, GuestReadDto>();
            CreateMap<GuestCreateDto, Guest>();
            CreateMap<GuestReadDto, GuestPublishedDto>();
        }
    }
}
