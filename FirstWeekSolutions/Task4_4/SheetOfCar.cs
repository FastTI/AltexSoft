using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_4
{
    class SheetOfCar
    {
        public string Model { get; set; }
        public string NumOfCar { get; set; }
        public string Surname { get; set; }
        public int YearOfBuy { get; set; }
        public float Mileage { get; set; }
    }

    class ComparerSheetOfCar:IComparer<SheetOfCar>
    {
        public int Compare(SheetOfCar c1, SheetOfCar c2)
        {
            if (c1.Mileage > c2.Mileage)
                return 1;
            else if (c1.Mileage < c2.Mileage)
                return -1;
            else
                return 0;
        } 
    }
}
