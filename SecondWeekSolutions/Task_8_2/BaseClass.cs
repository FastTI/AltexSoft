using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Task_8_1;

namespace Task_8_2
{
    class BaseClass
    {

        private IntPtr unManageResource;

        //Just test object for demonstrate manage source
        public TestManagedSource ManageSource { get; set; }


        //Allocates memory from the unmanaged memory of the process
        public void AddValueToUnmanageResource()
        {
            unManageResource = Marshal.AllocHGlobal(100);
        }
       

        bool disposed = false;

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
                Console.WriteLine("Dispose manage resources from base class");
            }
            Marshal.FreeHGlobal(unManageResource);
            Console.WriteLine("Dispose unmanage resources from base class");
            disposed = true;
        }

        ~BaseClass()
         {
             Dispose(true);
         }
    }
}
