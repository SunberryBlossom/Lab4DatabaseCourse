using System;
using System.Collections.Generic;

namespace Lab4.Domain.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Personnummer { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
