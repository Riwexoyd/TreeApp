using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.ApplicationServices.Models
{
    public sealed class TreeAge
    {
        private readonly DateTime _creationDate;

        public TreeAge(DateTime date)
        {
            _creationDate = date;
        }

        public override string ToString()
        {
            var date = _creationDate.Date;
            var currentDate = DateTime.UtcNow.Date;

            var years = 0;
            var months = 0;
            var days = 0;

            while (date.AddYears(1) < currentDate)
            {
                date = date.AddYears(1);
                ++years;
            }

            while (date.AddMonths(1) < currentDate)
            {
                date = date.AddMonths(1);
                ++months;
            }

            while (date.AddDays(1) < currentDate)
            {
                date = date.AddDays(1);
                ++days;
            }

            return $"{years} л. {months} м. {days} д.";
        }
    }
}
