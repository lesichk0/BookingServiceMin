using BookingService.Data;
using BookingService.Data.Interfaces;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IGenericRepo<Guest>, GuestRepo>();
builder.Services.AddScoped<IGenericRepo<Room>, RoomRepo>();
builder.Services.AddScoped<IGenericRepo<Reservation>, ReservationRepo>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
