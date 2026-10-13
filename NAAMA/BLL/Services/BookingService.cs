using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public Task<Booking?> GetBookingByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task CreateBookingAsync(Booking booking)
        {
            await _repository.AddAsync(booking);
        }
    }
}