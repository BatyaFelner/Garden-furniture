using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Buy
{
    public short Id { get; set; }

    public string? CodeClient { get; set; }

    public DateTime? Date { get; set; }

    public short? SumPrice { get; set; }

    public string? Note { get; set; }

    public bool? StatusBuy { get; set; }

    public virtual Client? CodeClientNavigation { get; set; }

    public virtual List<PurchaseDetail> PurchaseDetails { get; set; }
}
