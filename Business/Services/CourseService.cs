using Lab4.Business.DTOs;
using Lab4.Data.Interfaces;
using Lab4.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Business.Services
{
    internal class CourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<ActiveCoursesDto> GetAllActiveCourses()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            return _uow.Course.GetAllActiveCourses()
            .Select(c => new ActiveCoursesDto
            {
                CourseTitle = c.Title,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                DaysLeft = c.EndDate.DayNumber - today.DayNumber

            })
            .ToList();
        }
    }
}
