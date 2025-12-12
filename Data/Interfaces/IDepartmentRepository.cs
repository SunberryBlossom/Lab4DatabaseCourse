using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IDepartmentRepository
    {
        void AddDepartment();
        List<Department> GetAllDepartments();
        void UpdateDepartmentInfo(Department department);
        void RemoveDepartment(Department department);
    }
}
