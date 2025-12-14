using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
