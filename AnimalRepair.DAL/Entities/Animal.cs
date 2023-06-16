using System;
using System.Collections.Generic;

namespace Animal_Repair;

public partial class Animal
{
    public int Id { get; set; }

    public int IdKindOfAnimal { get; set; }

    public int? IdOrder { get; set; }

    public int IdGender { get; set; }

    public string DateOfBirth { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Picture { get; set; }

    public virtual KindOfGender IdGenderNavigation { get; set; } = null!;

    public virtual KindOfAnimal IdKindOfAnimalNavigation { get; set; } = null!;

    public virtual Order? IdOrderNavigation { get; set; }
}
