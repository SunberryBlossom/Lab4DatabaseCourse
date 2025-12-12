using Lab4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Data.Interfaces
{
    internal interface IClassRepository
    {
        void AddClass();

        List<Class> GetAllClasses();
        void UpdateClassInfo(Class @class);
        void RemoveClass(Class @class);
    }
}
