using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class MarriageHall
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public ICollection<MarriageHallServices> MarriageHallServices { get; set; } 

    }
}
