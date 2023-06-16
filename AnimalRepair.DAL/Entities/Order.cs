using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class Order
{
    public int Id { get; set; }

    public int IdCustomer { get; set; }

    public string Date { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual Customer IdCustomerNavigation { get; set; } = null!;
}
