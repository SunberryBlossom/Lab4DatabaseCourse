using Lab4.Data.Interfaces;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class ClassRepository : IClassRepository
    {
        private readonly Lab4DBContext _context;

        public ClassRepository(Lab4DBContext context)
        {
            _context = context;
        }

        public IQueryable<Class> GetAllClasses()
        {
            return _context.Classes;
        }
    }
}
