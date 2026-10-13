using BLL.Repositories;
using DAL.Models;

namespace BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public Task<Payments?> GetPaymentByBookingIdAsync(int bookingId) =>
            _repository.GetLatestByBookingIdAsync(bookingId);

        public async Task ProcessPaymentAsync(Payments payment)
        {
            ArgumentNullException.ThrowIfNull(payment);

            if (payment.CreateAt == default)
            {
                payment.CreateAt = DateTime.UtcNow;
            }

            await _repository.AddAsync(payment);
        }
    }
}