using System;
using System.Collections.Generic;

namespace Dto;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string? ClientName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? BearthDate { get; set; }

   /* public virtual ICollection<Buy> Buys { get; } = new List<Buy>();*/
}
