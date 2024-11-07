using AutoMapper;
using BookingService.Data.Interfaces;
using BookingService.DTOs.GuestDTOs;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepo _guestRepo;
        private readonly IMapper _mapper;

        public GuestController(IGuestRepo guestRepo, IMapper mapper)
        {
            _guestRepo = guestRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GuestReadDto>>> GetGuests()
        {
            Console.WriteLine("--> Getting Guests....");

            var guestItem = await _guestRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<GuestReadDto>>(guestItem));
        }

        [HttpGet("{id}", Name = "GetGuestById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GuestReadDto>> GetGuestById(int id)
        {
            var guestItem = await _guestRepo.GetByIdAsync(id);
            if (guestItem != null)
            {
                return Ok(_mapper.Map<GuestReadDto>(guestItem));
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GuestReadDto>> CreateGuest(GuestCreateDto guestCreateDto)
        {
            var guestModel = _mapper.Map<Guest>(guestCreateDto);
            await _guestRepo.InsertAsync(guestModel);
            _guestRepo.SaveChanges();

            var guestReadDto = _mapper.Map<GuestReadDto>(guestModel);
            return CreatedAtRoute(nameof(GetGuestById), new { Id = guestReadDto.Id }, guestReadDto);
        }
    }
}
