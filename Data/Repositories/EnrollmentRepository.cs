using Lab4.Data.Interfaces;
using Lab4.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly Lab4DBContext _context;

        public EnrollmentRepository(Lab4DBContext context)
        {
            _context = context;
        }

        public void Add(Enrollment grade)
        {
            _context.Add(grade);
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return _context.Enrollments.FirstOrDefault(e => e.Id == id);
        }
    }
}
