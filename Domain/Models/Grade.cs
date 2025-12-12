using System;
using System.Collections.Generic;

namespace Lab4.Domain.Models;

public partial class Grade
{
    public int Id { get; set; }

    public decimal? Grade1 { get; set; }

    public DateOnly? DateOfGrade { get; set; }

    public int TeacherId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Staff Teacher { get; set; } = null!;
}
