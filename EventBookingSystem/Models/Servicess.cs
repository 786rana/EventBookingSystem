﻿using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class Servicess
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<MarriageHallService> MarriageHallServices { get; set; } = new List<MarriageHallService>();
}
