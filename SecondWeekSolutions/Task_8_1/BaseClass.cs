using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    class BaseClass:IDisposable
    {

        private TestManagedSource manageSource;

        public TestManagedSource ManageSource
        {
            get { return manageSource; }
            set { manageSource = value; }
        }


        //implementation dispose method without finalize
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);   
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                manageSource = null;
                Console.WriteLine("Dispose manage resources from base class");
            }
                Console.WriteLine("Dispose umanage resources from base class");

            disposed = true;
        }









    }
}
