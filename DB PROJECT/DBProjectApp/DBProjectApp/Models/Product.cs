using System;
using System.Collections.Generic;

namespace DBProjectApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public int? FK_CategoryId { get; set; }

    public virtual Category? FK_Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
