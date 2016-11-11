using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Disk
    {

        public static uint diskCounter = 0;

        public string Name { get; set; }

        public  uint ID { get; set; }

        public  uint CatalogID { get; set; }

        public static List<Song> listOfSong = new List<Song>();

        public Disk()
        {
            
        }
      
        public Disk(string name, uint id)
        {
            this.Name = name;
            this.ID = id;
            //this.CatalogID = catalogID;
        }

        public static void ShowAllDisks()
        {
            foreach (var disc in Catalog.ListOfDisk)
            {
                Console.WriteLine(disc.ToString());
            }

        }

        public static void AddDisk(string name, uint id)
        {
            Catalog.ListOfDisk.Add(new Disk(name,id));
        }

        public static void FindDisk(string name)
        {
            foreach (var disc in Catalog.ListOfDisk)
            {
                if (disc.Name == name)
                {
                    Console.WriteLine(disc.Name);
                    foreach (var song in Disk.listOfSong)
                    {
                        if (disc.ID == song.DiskId)
                        {
                            Console.WriteLine("     {0}-{1}",song.Artist,song.NameOfSong);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}",ID,Name);
        }
    }
}
