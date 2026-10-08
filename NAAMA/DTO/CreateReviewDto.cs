namespace RideSharing.DTOs
{
    public class CreateReviewDto
    {
        public string RideId { get; set; }
        public string ReviewedUserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}