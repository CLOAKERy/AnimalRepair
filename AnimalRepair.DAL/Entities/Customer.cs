using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class Customer
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public int IdLogin { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual Login IdLoginNavigation { get; set; } = null!;

    public virtual UserRole IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
