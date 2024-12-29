using System;
using System.Collections.Generic;

namespace DBProjectApp.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? FK_OrderId { get; set; }

    public DateTime? PaymnetDate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Order? FK_Order { get; set; }
}
