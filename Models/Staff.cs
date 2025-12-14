using System;
using System.Collections.Generic;

namespace Lab4.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public int MonthlySalary { get; set; }

    public int StaffTypeId { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual StaffType StaffType { get; set; } = null!;
}
