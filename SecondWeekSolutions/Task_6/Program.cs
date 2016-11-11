using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
          
            

            UserChoise.CreateCatalog();
        
            Console.WriteLine("Now you have simple catalogue \n choose next action");

            do
            {
                Console.WriteLine(
                    "1.Add disks to catalog\n2.Add songs to disk\n3.Search Artist\n4.Show catalog\n5.Show disk\n6.Delete songs\n7.Delete Disks");

               uint choise = UserChoise.CheckUintUserInput(Console.ReadLine());
           
                switch (choise)
                {
                    case 1:
                        UserChoise.AddDiscToCatalogue();
                        break;
                    case 2:
                        UserChoise.AddSongsToDisc();
                        break;
                    case 3:
                        UserChoise.ArtistSearch();
                        break;
                    case 4:
                        UserChoise.AllCatalog();
                        break;
                    case 5:
                        UserChoise.ShowDisk();
                        break;
                    case 6:
                        UserChoise.DeleteSong();
                        break;
                    case 7:
                        UserChoise.DeleteDisk();
                        break;
                    default:
                        Console.WriteLine("No correct number");
                        break;
                }
            } while (UserChoise.EscPress("\nClose app or continue your action\nPress any key to continue or press ESC to exit"));


















            /*Console.WriteLine("Enter catalog where you want to add disks\nYou have that catalogues");

            Catalog.ShowCatalogs();

            Console.WriteLine("Enter Number in what catalogue do you want write disks");

///////////////////////////////////////////////////////////////////////////////
            /*uint numOfCatalog = 0;
            var input = Console.ReadLine();
            while (!uint.TryParse(input, out numOfCatalog))
            {
                Console.WriteLine("Enter correct number");
               input = Console.ReadLine();
            }
            
            foreach (var cat in Catalog.ListOfCatalogs)
            {
                if (cat.ID == numOfCatalog) ;

            }


///////////////////////////////////////////////////////////////////////////////////
                foreach (var catalogs in Catalog.ListOfCatalogs)
                {
                    if (catalogs.ID == numOfCatalog)
                    {
                        Console.Clear();
                        Console.WriteLine("now your in catalog {0} \n enter the disks name", catalogs.Name);
                        do
                        {
                            Console.WriteLine("Next disc:");
                            var a = Console.ReadLine();
                            //string[] arrTemp = a.Split(';');

                            Disk.AddDisk(a, idDisc++, catalogs.ID);
                        } while (EscPress());
                    }

                }
            
          
            Console.Clear();



            Console.WriteLine("Enter disc where you want to add song");
            Console.WriteLine("You have that disks");
            Disk.ShowAllDisks();
            Console.WriteLine("Enter Number in what disk do you want write songs");
            uint numOfDisk = Convert.ToUInt16(Console.ReadLine());

            foreach (var disc in Catalog.ListOfDisk)
            {
                if (disc.ID ==  numOfDisk)
                {
                    Console.Clear();
                    Console.WriteLine("now you in disk called {0} \n enter the songs Artist and NameOfSong",disc.Name );
                    do
                    {
                        Console.WriteLine("Next song:");
                        string nameOfSongs = Console.ReadLine();
                        string[] temp = nameOfSongs.Split(';');
                        Song.AddSong(temp[0],temp[1],songId++,disc.ID);
                    } while (EscPress());
                }
            }

            
            Console.WriteLine("Now you have simple catalogue \n choose next action");


            Console.WriteLine("1.Show me all catalogs\n2.Search disc\n3.Search concrete Artist\n");
            byte choise = Convert.ToByte(Console.ReadLine());


            switch (choise)
            {
                case 1:
                    Catalog.ShowAllInCatalogs();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter name of disk");
                    var diskName = Console.ReadLine();
                    Disk.FindDisk(diskName);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Enter artist");
                    var artistName = Console.ReadLine();
                    Song.FindSong(artistName);
                    break;
                default:
                    Console.WriteLine("Такой язык я не знаю");
                    break;
            }*/

        }
    }
}
