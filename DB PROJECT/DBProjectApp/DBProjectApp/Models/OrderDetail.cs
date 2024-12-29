using System;
using System.Collections.Generic;

namespace DBProjectApp.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? FK_OrderId { get; set; }

    public int? FK_ProductId { get; set; }

    public int? Quantitiy { get; set; }

    public decimal? Price { get; set; }

    public virtual Order? FK_Order { get; set; }

    public virtual Product? FK_Product { get; set; }
}
