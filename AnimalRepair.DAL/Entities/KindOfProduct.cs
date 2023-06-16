using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class KindOfProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
