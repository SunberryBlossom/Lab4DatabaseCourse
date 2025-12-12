using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IGradeRepository
    {
        void AddGrade();
        List<Student> GetAllGrades();
        void UpdateGradeInfo(Grade grade);
        void RemoveGrade(Grade grade);
    }
}
