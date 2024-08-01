using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class MarriageHallService
{
    public int Id { get; set; }

    public int MarriageHallId { get; set; }

    public int ServiceId { get; set; }

    public int Price { get; set; }

    public virtual MarriageHall MarriageHall { get; set; } = null!;

    public virtual Servicess Service { get; set; } = null!;
}
