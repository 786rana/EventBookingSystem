using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class MarriageHallServices
    {
        [Key]
        public int Id { get; set; }
        public int MarriageHallId { get; set; }
        public int ServiceId { get; set; }
        public int Price { get; set; }
    }
}
