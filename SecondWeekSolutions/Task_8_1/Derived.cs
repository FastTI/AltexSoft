using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_1
{
    class Derived:BaseClass
    {

        //Connect WinApi function (unmanage resourses)
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);



        #region Some implementation with manage and unmanage resources

        //Unmanage resource
        private IntPtr handleActive;


     

        public void ShowWindowDescriptor()
        {
            handleActive = GetForegroundWindow();
            Console.WriteLine(handleActive);
        }

        public string ShowNameActiveWindow()
        {
            int pid;
            string result = "";
            GetWindowThreadProcessId(handleActive, out pid);
            result = System.Diagnostics.Process.GetProcessById(pid).ProcessName;
            return result;
        }

        #endregion

        #region Dispose implementation

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
               Console.WriteLine("Dispose manage resources from derived class");
           }
           handleActive = new IntPtr();
           Console.WriteLine("Dispose umanage resources from derived class");

           disposed = true;

           // Call the base class implementation.
           base.Dispose(disposing);
       }

       ~Derived()
       {
           Dispose(true);
       }
        #endregion



    }


}
