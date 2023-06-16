using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class KindOfGender
{
    public int Id { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
