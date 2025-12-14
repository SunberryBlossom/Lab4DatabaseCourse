using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IStaffRepository
    {
        void AddStaff(string firstName, string lastName, DateOnly date, int monthlySalary, int staffTypeId, int departmentId);
        List<Staff> GetAllStaff();
        // Staff GetStaffById();
        // void UpdateStaffInfo(Staff staff);
        // void RemoveStaffById();
        List<Staff> GetAllTeachers();

        Staff GetTeacherById(int id);
    }
}
