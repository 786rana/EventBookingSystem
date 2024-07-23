using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool Vendor { get; set; }

    public virtual ICollection<MarriageHall> MarriageHalls { get; set; } = new List<MarriageHall>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
