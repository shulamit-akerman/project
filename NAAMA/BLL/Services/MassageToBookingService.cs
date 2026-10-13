using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class MassageToBookingService : IMassageToBookingService
    {
        private readonly IMassageToBookingRepository _repository;

        public MassageToBookingService(IMassageToBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(MassageToBooking massageToBooking)
        {
            await _repository.AddAsync(massageToBooking);
        }

        public async Task<IEnumerable<MassageToBooking>> GetMessagesByBookingIdAsync(int bookingId)
        {
            return await _repository.GetByBookingIdAsync(bookingId);
        }
    }
}