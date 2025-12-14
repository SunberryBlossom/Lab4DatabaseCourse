using Lab4.Data.Interfaces;
using Lab4.Models;
using Lab4.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Business.Services
{
    internal class StudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<StudentClassCourseGradeGroupDto> GetInfoAboutAllStudents()
        {
            var flat = _uow.Student.GetAllStudents()
                .Include(s => s.Class)
                .Include(s => s.Enrollments)
                .ThenInclude(g => g.Course)
                .SelectMany(
                    s => s.Enrollments,
                    (student, grade) => new
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        NameOfClass = student.Class.ClassTitle,
                        CourseTitle = grade.Course.Title,
                        Grade = grade.Grade 
                    })
                .AsEnumerable();

            return flat
                .GroupBy(x => new { x.FirstName, x.LastName, x.NameOfClass })
                .Select(g => new StudentClassCourseGradeGroupDto
                {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    NameOfClass = g.Key.NameOfClass,
                    Courses = string.Join(", ", g.Select(x => x.CourseTitle)),
                    Grades = string.Join(", ", g.Select(x => x.Grade.HasValue ? x.Grade.ToString() : "not graded yet"))
                })
                .ToList();
        }
    }
}