using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Company
{
    public short Id { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
