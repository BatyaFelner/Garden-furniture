using System;
using System.Collections.Generic;

namespace Dto;

public partial class Buy
{
    public short Id { get; set; }

    public string? CodeClient { get; set; }

    public DateTime? Date { get; set; }

    public int? SumPrice { get; set; }

    public int? SumCount { get; set; }

    public string? Note { get; set; }


    public string? ClientName { get; set; }

    public List<Product>? PurchaseDetails { get; set; } = new List<Product>();

}