using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_1;

namespace Task_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass baseElement = new BaseClass();
            baseElement.AddValueToUnmanageResource();
            baseElement.ManageSource = new TestManagedSource();

            //If not use dispose method than will work finalizer 
            baseElement.Dispose();



            DerivedClass derivedElement = new DerivedClass();
            derivedElement.ManageSource2 = new TestManagedSource();
            //If not use dispose method than will work finalizer 
            derivedElement.Dispose();
            


        }
    }
}
