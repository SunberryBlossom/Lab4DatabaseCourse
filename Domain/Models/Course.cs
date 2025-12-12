using System;
using System.Collections.Generic;

namespace Lab4.Domain.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
