using Lab4.Data.Interfaces;
using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly Lab4DBContext _context;

        public StudentRepository(Lab4DBContext context)
        {
            _context = context;
        }

        public IQueryable<Student> GetAllStudents()
        {
            return _context.Students;
        }
    }
}
