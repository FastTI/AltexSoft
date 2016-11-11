using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Catalog
    {
 
        public static string Name { get; set;}

        public static List<Disk> ListOfDisk = new List<Disk>();
        
        public static void CatalogCreate(string catalogName)
        {
            Catalog.Name = catalogName;
        }
        
        public static void ShowCatalogName()
        {
            Console.WriteLine(Catalog.Name);
        }

        public static void ShowAllInCatalogs()
        {
            
                Console.WriteLine("Catalog: {0}\n",Catalog.Name);
                foreach (var disk in ListOfDisk)
                {
                    Console.WriteLine(new string(' ',10) + disk.Name);
                    foreach (var song in Disk.listOfSong)
                    {
                      if (song.DiskId == disk.ID)
                      {
                           Console.WriteLine("              {0}-{1}",song.Artist,song.NameOfSong);
                      }
                    }
                }
            
        }

        public override string ToString()
        {
            return String.Format("NameOfCatalogue: {0}",Name);
        }
    }
}
