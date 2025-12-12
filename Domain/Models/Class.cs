using System;
using System.Collections.Generic;

namespace Lab4.Domain.Models;

public partial class Class
{
    public int Id { get; set; }

    public string ClassTitle { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int TeacherId { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Staff Teacher { get; set; } = null!;
}
