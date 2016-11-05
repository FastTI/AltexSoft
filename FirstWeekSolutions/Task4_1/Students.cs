using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    struct Students : IComparer<Students>
    {
        public string FSP { get; set; } //FirstNameSurnamePatronymic
        public DateTime BirthDay { get; set; }
        public string Adress { get; set; }
        public int NumberOfSchool { get; set; }

        public int Compare(Students s1, Students s2)
        {
            if (s1.BirthDay.Year > s2.BirthDay.Year)
                return 1;
            else if (s1.BirthDay.Year < s2.BirthDay.Year)
                return -1;
            else
                return 0;
        }

    }
}
