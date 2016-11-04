using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_3
{
    class BaggageList:IComparer<BaggageList>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int NumOfThings { get; set; }
        public float ThingsWeight { get; set; }

        public int Compare(BaggageList b1, BaggageList b2)
        {
            if (b1.NumOfThings > b2.NumOfThings)
                return 1;
            else if (b1.NumOfThings < b2.NumOfThings)
                return -1;
            else
                return 0;
        }
    }
}
