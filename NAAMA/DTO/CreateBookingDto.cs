namespace RideSharing.DTOs
{
    public class CreateBookingDto
    {
        public string RideId { get; set; }
        public int RequestedSeats { get; set; }
        public string PickupNotes { get; set; }
    }
}