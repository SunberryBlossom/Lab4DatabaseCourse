using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Business.DTOs
{
    internal class ActiveCoursesDto
    {
        public string CourseTitle { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int DaysLeft { get; set; }
    }
}
