using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            //if (isProd)
            //{
            //    Console.WriteLine("--> Attempting to apply migrations...");
            //    try
            //    {
            //        context.Database.Migrate();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            //    }
            //}

            // Seed Guests
            if (!context.Guests.Any())
            {
                Console.WriteLine("--> Seeding Guests...");
                context.Guests.AddRange(
                    new Guest { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                    new Guest { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210" },
                    new Guest { Id = 3, FirstName = "Emily", LastName = "Johnson", Email = "emily.johnson@example.com", PhoneNumber = "555-123-4567" }
                );
            }

            // Seed Rooms
            if (!context.Rooms.Any())
            {
                Console.WriteLine("--> Seeding Rooms...");
                context.Rooms.AddRange(
                    new Room { Id = 1, RoomNumber = "101", RoomType = "Single", PricePerNight = 75.00m },
                    new Room { Id = 2, RoomNumber = "102", RoomType = "Double", PricePerNight = 120.00m },
                    new Room { Id = 3, RoomNumber = "103", RoomType = "Suite", PricePerNight = 200.00m }
                );
            }

            // Seed Reservations
            if (!context.Reservations.Any())
            {
                Console.WriteLine("--> Seeding Reservations...");
                context.Reservations.AddRange(
                    new Reservation { Id = 1, GuestId = 1, RoomId = 1, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(3), Status = "Booked" },
                    new Reservation { Id = 2, GuestId = 2, RoomId = 2, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(2), Status = "Checked In" },
                    new Reservation { Id = 3, GuestId = 3, RoomId = 3, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now.AddDays(5), Status = "Confirmed" }
                );
            }

            context.SaveChanges();
            Console.WriteLine("--> Seeding completed.");

        }
    }
}
