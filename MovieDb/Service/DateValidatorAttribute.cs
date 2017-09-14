using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDb.Service
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime todayDate = DateTime.Today;
            DateTime releaseDate = (DateTime)date;
            //                            -1-earlier  0   1-later
            int result = DateTime.Compare(todayDate, releaseDate);
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}