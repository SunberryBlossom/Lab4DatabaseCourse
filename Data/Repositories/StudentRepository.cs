using Lab4.Data.Interfaces;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly Lab4DBContext _context;
        private readonly DbSet<Student> _dbSet;

        public StudentRepository(Lab4DBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Student>();
        }

        public IQueryable<Student> GetAllStudents()
        {
            return _context.Students;
        }
    }
}
