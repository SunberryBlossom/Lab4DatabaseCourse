using Lab4.Business.DTOs;
using Lab4.Data;
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lab4.Business.Services
{
    internal class DepartmentService
    {
        private readonly IUnitOfWork _uow;

        public DepartmentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<DepartmentTeacherCountDto> AmountOfTeachersPerDepartment()
        {
            return _uow.Department
                .GetAllDepartments()
                .Include(d => d.Staff)
                .Select(d => new DepartmentTeacherCountDto { DepartmentTitle = d.Title, NumberOfTeachers = d.Staff.Count(s => s.StaffTypeId == 1) })
                .ToList();
        }
    }
}