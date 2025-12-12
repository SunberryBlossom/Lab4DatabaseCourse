using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IStaffRepository
    {
        internal void AddStaff();
        internal List<Staff> GetAllStaff();
        internal Staff GetStaffById();
        internal void UpdateStaffInfo(Staff staff);
        internal void RemoveStaffById();
        internal List<Staff> GetAllTeachers();
    }
}
