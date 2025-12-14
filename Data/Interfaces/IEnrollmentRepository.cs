using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IEnrollmentRepository
    {
        void Add(Enrollment grade);
        Enrollment GetEnrollmentById(int id);
        //List<Student> GetAllGrades();
        //void UpdateGradeInfo(Grade grade);
        //void RemoveGrade(Grade grade);
    }
}
