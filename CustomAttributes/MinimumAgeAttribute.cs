using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.CustomAttributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime birthDate = (DateTime)value;
                if (DateTime.Today.Year - birthDate.Year < _minimumAge)
                {
                    return false;
                }
            }
            return true;
        }
    }
}