using System;
using System.Collections.Generic;

namespace Lab4.Domain.Models;

public partial class StaffType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
