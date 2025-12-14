using Lab4.Data;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Business.Services
{
    internal class EnrollmentService
    {
        private readonly UnitOfWork _uow;

        public EnrollmentService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public void SetGrade(int enrollmentId, decimal gradePoint)
        {
            Enrollment enrollment = _uow.Enrollment.GetEnrollmentById(enrollmentId);

            if (gradePoint > 10.0m || gradePoint < 0.0m)
            {
                throw new ArgumentException("The grade must be between 0.0 and 10.0");
            }
            else if (enrollment == null)
            {
                throw new InvalidOperationException("There is no enrollment with that ID.");
            }
            else if (enrollment.Grade != null || enrollment.DateOfGrade != null)
            {
                throw new InvalidOperationException("Grades can only be set once. Contact Radagast the Brown for help with changing an already set grade.");
            }

            _uow.BeginTransaction();
            try
            {
                enrollment.Grade = gradePoint;
                enrollment.DateOfGrade = DateOnly.FromDateTime(DateTime.Now);

                _uow.Enrollment.Update(enrollment);
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
