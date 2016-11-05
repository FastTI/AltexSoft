using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_4
{
    struct SheetOfCar
    {
        public string Model { get; set; }
        public string NumOfCar { get; set; }
        public string Surname { get; set; }
        public int YearOfBuy { get; set; }
        public float Mileage { get; set; }

        public override string ToString()
        {
            return String.Format("Model: {0}\nRegistration Mark: {1}\nOwner's Surname: {2}\nYear of by: {3}\nMileage: {4} km\n"
                    , Model, NumOfCar, Surname, YearOfBuy,Mileage);
        }
    }

    struct ComparerSheetOfCar:IComparer<SheetOfCar>
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
