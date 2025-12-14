using Lab4.Data.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly Lab4DBContext _context;

        public DepartmentRepository(Lab4DBContext context)
        {
            _context = context;
        }
        public IQueryable<Department> GetAllDepartments()
        {
            return _context.Departments;
        }

        public int GetNumOfDepartments()
        {
            return _context.Departments.Count();
        }

        public Department GetDepartmentById(int id)
        {
           var departments = GetAllDepartments();

            return departments.FirstOrDefault(d => d.Id == id);

        }
    }
}
