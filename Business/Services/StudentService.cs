using Lab4.Data.Interfaces;
using Lab4.Models;
using Lab4.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4.Business.Validators;

namespace Lab4.Business.Services
{
    internal class StudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly StudentValidator _studentValidator;
        private readonly ClassValidator _classValidator;

        public StudentService(IUnitOfWork uow, StudentValidator studentValidator, ClassValidator classValidator)
        {
            _uow = uow;
            _studentValidator = studentValidator;
            _classValidator = classValidator;
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

        public void UpdateStudentInfo(int studentId, string firstName, string lastName, string personnummer, string address, string email, int classId)
        {
            Student student = _uow.Student.GetStudentById(studentId);

            if (!_studentValidator.IsValidPersonnummerFormat(personnummer))
            {
                throw new ArgumentException("The swedish personnummer is not in the correct format");
            }
            else if (!_studentValidator.IsValidEmailFormat(email))
            {
                throw new ArgumentException("The email address is not in a correct format");
            }
            else if (!_classValidator.ClassExists(classId))
            {
                throw new ArgumentException("There is no class connected to the inputted class ID");
            }

            _uow.BeginTransaction();
            try
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Personnummer = personnummer;
                student.Address = address;
                student.Email = email;
                student.ClassId = classId;
                _uow.Student.Update(student);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                throw;
            }


        }
    }
}