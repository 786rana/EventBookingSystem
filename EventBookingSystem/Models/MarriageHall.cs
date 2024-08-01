using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class MarriageHall
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Location { get; set; } = null!;


    public string Details { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<MarriageHallService> MarriageHallServices { get; set; } = new List<MarriageHallService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
