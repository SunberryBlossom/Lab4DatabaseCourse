using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface ICourseRepository
    {
        //void AddCourse();
        Course GetCourseById(int id);
        IQueryable<Course> GetAllCourses();
        IQueryable<Course> GetAllActiveCourses();
        //void UpdateCourseInfo(Course course);
        //void RemoveCourse(Course course);
    }
}
