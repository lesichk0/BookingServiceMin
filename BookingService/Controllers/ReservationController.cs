using AutoMapper;
using BookingService.Data;
using BookingService.Data.Interfaces;
using BookingService.DTOs.GuestDTOs;
using BookingService.DTOs.ReservationDTOs;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepo _reservationRepo;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepo reservationRepo, IMapper mapper)
        {
            _reservationRepo = reservationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReservationReadDto>>> GetReservations()
        {
            Console.WriteLine("--> Getting Reservations....");

            var reservationItem = await _reservationRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ReservationReadDto>>(reservationItem));
        }

        [HttpGet("{id}", Name = "GetReservationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReservationReadDto>> GetReservationById(int id)
        {
            var reservationItem = await _reservationRepo.GetByIdAsync(id);
            if (reservationItem != null)
            {
                return Ok(_mapper.Map<ReservationReadDto>(reservationItem));
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReservationReadDto>> CreateGuest(ReservationCreateDto reservationCreateDto)
        {
            var reservationModel = _mapper.Map<Reservation>(reservationCreateDto);
            await _reservationRepo.InsertAsync(reservationModel);
            _reservationRepo.SaveChanges();

            var reservationReadDto = _mapper.Map<ReservationReadDto>(reservationModel);
            return CreatedAtRoute(nameof(GetReservationById), new { Id = reservationReadDto.Id }, reservationReadDto);
        }
    }
}
