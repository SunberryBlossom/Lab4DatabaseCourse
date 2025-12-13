using Lab4.Data.Interfaces;
using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Data.Repositories
{
    internal class StaffRepository : IStaffRepository
    {

        private readonly Lab4DBContext _context;

        public StaffRepository(Lab4DBContext context)
        {
            _context = context;
        }

        public void AddStaff(string firstName, string lastName, DateOnly date, int monthlySalary, int staffTypeId, int departmentId)
        {
            var staff = new Staff();
            staff.FirstName = firstName;
            staff.LastName = lastName;
            staff.StartDate = date;
            staff.MonthlySalary = monthlySalary;
            staff.StaffTypeId = staffTypeId;
            staff.DepartmentId = departmentId;

            _context.Staff.Add(staff);
        }

        public List<Staff> GetAllStaff()
        {
            return _context.Staff.ToList();
        }

        public List<Staff> GetAllTeachers()
        {
            return _context.Staff.Where(s => s.StaffTypeId == 1).ToList();
        }
    }
}