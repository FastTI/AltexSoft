using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Task_8_1;

namespace Task_8_2
{
    class DerivedClass:BaseClass
    {

        bool disposed = false;

        public TestManagedSource ManageSource2 { get; set; }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                Console.WriteLine("object was deleted");
                return;
            }
            if (disposing)
            {
                Console.WriteLine("Dispose manage resources from derived class");
            }
            Console.WriteLine("Dispose unmanage resources from derived class");
            disposed = true;

            base.Dispose(disposing);
        }




    }
}
