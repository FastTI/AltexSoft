using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_8_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Derived derivedElement = new Derived();
            derivedElement.ManageSource = new TestManagedSource();
            Console.WriteLine("Descriptor of active window");
            derivedElement.ShowWindowDescriptor();
            Console.WriteLine();
            derivedElement.Dispose();
            // If call Dispose second time variable disposed will be true and cleaning will not happen 
            derivedElement.Dispose(); 




        }

      


    }
}
