using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IStudentRepository
    {
        // void AddStudent();
        void Update(Student student);
        IQueryable<Student> GetAllStudents();
        Student GetStudentById(int id);
        //void RemoveStudent(Student student);
    }
}
