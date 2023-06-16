using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class Product
{
    public int Id { get; set; }

    public int IdKindOfProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public string? Picture { get; set; }

    public virtual KindOfProduct IdKindOfProductNavigation { get; set; } = null!;
}
