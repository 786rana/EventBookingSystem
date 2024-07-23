using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public  string Name { get; set; }
        public int UserId { get; set; }
        public int NetAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public ICollection<MarriageHall> MarriagesHall { get; set; }
        public ICollection<Services> Services { get; set; }
    }

}
