using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class Servicess
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }
}
