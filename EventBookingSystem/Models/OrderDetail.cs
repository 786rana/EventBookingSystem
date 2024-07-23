using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ServiceId { get; set; }

    public int MarriageHallId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public decimal Amount { get; set; }

    public virtual Order Order { get; set; } = null!;
}
