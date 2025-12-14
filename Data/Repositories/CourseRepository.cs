using Lab4.Data.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly Lab4DBContext _context;
        public CourseRepository(Lab4DBContext context)
        {
            _context = context;
        }

        public IQueryable<Course> GetAllActiveCourses()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return _context.Courses.Where(c => c.EndDate >= today  && c.StartDate < today);
        }
    }
}
