using Lab4.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Business.Validators
{
    internal class ClassValidator
    {
        private readonly IUnitOfWork _uow;

        public ClassValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool ClassExists(int classId)
        {
            if (classId <= 0)
            {
                return false;
            }


            return _uow.Class.GetAllClasses().Any(c => c.Id == classId);
        }
    }

}
