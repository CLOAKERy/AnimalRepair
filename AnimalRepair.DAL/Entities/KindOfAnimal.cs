using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class KindOfAnimal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
