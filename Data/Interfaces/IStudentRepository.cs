using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IStudentRepository
    {
        void AddStudent() { }

        List<Student> GetAllStudents()
        {
            return null;
        }

        void UpdateStudentInfo(Student student)
        {

        }

        void RemoveStudent(Student student) { }
    }
}
