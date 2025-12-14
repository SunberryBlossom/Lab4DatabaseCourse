using Lab4.Data;
using Lab4.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Lab4.Business.Validators
{
    internal class StudentValidator
    {
        private const string PersonnummerPattern = @"^(\d{6}|\d{8})([-\+])?(\d{4})$";
        private readonly IUnitOfWork _uow;

        public StudentValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool IsValidPersonnummerFormat(string input)
        {
            return Regex.IsMatch(input, PersonnummerPattern);
        }
        public bool IsValidEmailFormat(string email)
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
    }
}
