using AutoMapper;
using BookingService.Data;
using BookingService.Data.Interfaces;
using BookingService.DTOs.ReservationDTOs;
using BookingService.DTOs.RoomDTOs;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepo roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRooms()
        {
            Console.WriteLine("--> Getting Rooms....");

            var roomItem = await _roomRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(roomItem));
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomReadDto>> GetRoomById(int id)
        {
            var roomItem = await _roomRepo.GetByIdAsync(id);
            if (roomItem != null)
            {
                return Ok(_mapper.Map<RoomReadDto>(roomItem));
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReservationReadDto>> CreateGuest(RoomCreateDto roomCreateDto)
        {
            var roomModel = _mapper.Map<Room>(roomCreateDto);
            await _roomRepo.InsertAsync(roomModel);
            _roomRepo.SaveChanges();

            var roomReadDto = _mapper.Map<RoomReadDto>(roomModel);
            return CreatedAtRoute(nameof(GetRoomById), new { Id = roomReadDto.Id }, roomReadDto);
        }
    }
}
