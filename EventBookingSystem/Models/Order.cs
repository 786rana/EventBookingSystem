using System;
using System.Collections.Generic;

namespace EventBookingSystem.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? MarriageHallId { get; set; }

    public decimal Total { get; set; }

    public decimal Tip { get; set; }

    public decimal NetAmount { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal? BalanceAmount { get; set; }

    public string? Remarks { get; set; }

    public virtual MarriageHall? MarriageHall { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; } = null!;
}
