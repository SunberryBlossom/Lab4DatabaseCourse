using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IUnitOfWork
    {
        ICourseRepository Course { get; }
        IDepartmentRepository Department { get; }
        IEnrollmentRepository Enrollment { get; }
        IStudentRepository Student { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        int SaveChanges();
    }
}
