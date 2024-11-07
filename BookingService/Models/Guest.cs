﻿using System.ComponentModel.DataAnnotations;

namespace BookingService.Models
{
    public class Guest
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }


        public List<Reservation> Reservations { get; set; }

    }
}
