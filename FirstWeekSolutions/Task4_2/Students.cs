using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    class Students : IComparer<Students>
    {
        public string FSP { get; set; } //FirstNameSurnamePatronymic
        public int GroupNum { get; set; }
        public Dictionary<string, string> Ratings { get; set; } //Формат Key-Предмет Value-зачет/не зачет

        public int Compare(Students s1, Students s2)
        {
            if (s1.GroupNum > s2.GroupNum)
                return 1;
            else if (s1.GroupNum < s2.GroupNum)
                return -1;
            else
                return 0;
        }
    }
}