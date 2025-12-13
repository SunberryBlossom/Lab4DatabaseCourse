using Lab4.Business.DTOs;
using Lab4.Data;
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;
using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lab4.Business.Services
{
    internal class StaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StaffService(IStaffRepository staffRepository, IDepartmentRepository departmentRepository)
        {
            _staffRepository = staffRepository;
            _departmentRepository = departmentRepository;
        }

        public List<DepartmentTeacherCountDto> AmountOfTeachersPerDepartment()
        {
            var allDepartments = _departmentRepository.GetAllDepartments();

            return allDepartments.Select(d => new DepartmentTeacherCountDto {DepartmentTitle = d.Title, NumberOfTeachers = d.Staff.Count(s => s.StaffTypeId == 1)}).ToList();
        }
    }
}
