namespace EventBookingSystem.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int MarriageHallId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public virtual MarriageHall? MarriageHall { get; set; }
        public virtual Services? Services { get; set; }
        public virtual Order? Orders { get; set; }
    
    }
}
