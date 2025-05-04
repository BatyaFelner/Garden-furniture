using System;
using System.Collections.Generic;

namespace Dto;

public partial class PurchaseDetail
{
    public short? Id { get; set; }

    public short? CodeBuy { get; set; }

    public short? CodeProd { get; set; }

    public short? Amount { get; set; }

    public int? Price { get; set; }

    public string? ProductName { get; set; }
}



