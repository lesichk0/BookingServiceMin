using AutoMapper;
using BookingService.DTOs.ReservationDTOs;
using BookingService.Models;

namespace BookingService.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            // Source -> Target mappings
            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationReadDto, ReservationPublishedDto>();
        }
    }
}
