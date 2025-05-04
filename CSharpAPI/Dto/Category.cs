using System;
using System.Collections.Generic;

 namespace Dto;
public partial class Category
{
    public short Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
