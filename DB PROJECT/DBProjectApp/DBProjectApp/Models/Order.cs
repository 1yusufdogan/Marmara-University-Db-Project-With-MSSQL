using System;
using System.Collections.Generic;

namespace DBProjectApp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? FK_CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer? FK_Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
