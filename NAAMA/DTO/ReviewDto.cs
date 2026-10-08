using System;

namespace RideSharing.DTOs
{
    public class ReviewDto
    {
        public string Id { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}