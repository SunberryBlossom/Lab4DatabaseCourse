
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Lab4.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly Lab4DBContext _context;
        private IDbContextTransaction _currentTransaction;

        private IDepartmentRepository _department;
        private IEnrollmentRepository _enrollment;
        private IStaffRepository _staff;
        private IStudentRepository _student;
        private ICourseRepository _course;


        public UnitOfWork(Lab4DBContext context)
        {
            _context = context;
        }

        public IDepartmentRepository Department
        {
            get { return _department ??= new DepartmentRepository(_context); }
        }

        public IEnrollmentRepository Enrollment
        {
            get { return _enrollment ??= new EnrollmentRepository(_context); }
        }

        public IStaffRepository Staff
        {
            get { return _staff ??= new StaffRepository(_context); }
        }

        public IStudentRepository Student
        {
            get { return _student ??= new StudentRepository(_context); }
        }

        public ICourseRepository Course
        {
            get { return _course ??= new CourseRepository(_context); }
        }

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("A transaction to the database is already currently happening!");
            }

            _currentTransaction = _context.Database.BeginTransaction();
        }
        public void Commit()
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("There is no current transaction to commit to the database.");
            }

            try
            {
                _context.SaveChanges();
                _currentTransaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
        public void Rollback()
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Rollback();
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
