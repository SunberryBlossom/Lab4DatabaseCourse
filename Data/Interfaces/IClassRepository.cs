using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IClassRepository
    {
        IQueryable<Class> GetAllClasses();
    }
}
