using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class Admin
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public int IdLogin { get; set; }

    public string Name { get; set; } = null!;

    public virtual Login IdLoginNavigation { get; set; } = null!;

    public virtual UserRole IdRoleNavigation { get; set; } = null!;
}
