using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public decimal Total { get; set; }

    public decimal Discount { get; set; }

    public decimal NetAmount { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
