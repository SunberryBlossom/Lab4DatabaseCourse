using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface ICourseRepository
    {
        void AddCourse() { }

        List<Course> GetAllCourses()
        {
            return null;
        }

        void UpdateCourseInfo(Course course)
        {

        }

        void RemoveCourse(Course course) { }
    }
}
