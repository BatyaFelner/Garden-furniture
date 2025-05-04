using System;
using System.Collections.Generic;

namespace Dto;

public partial class Product
{
    public short? Id { get; set; }

    public string? NameP { get; set; }

    public short? CodeCat { get; set; }

    public short? CodeCom { get; set; }

    public string? Descrip { get; set; }

    public short? Price { get; set; }

    public string? Pic { get; set; }


    public short? Amount { get; set; }

    public short? TempAmount { get; set; } = 0;
    public DateTime? LastUpdate { get; set; }

    public string? CompenyName { get; set; }

    public string? codeCategoryName { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; } = new List<PurchaseDetail>();
}
