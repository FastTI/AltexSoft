using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_6
{
    class UserChoise
    {

        public static void CreateCatalog()
        {
            Console.WriteLine("Enter catalog name");
            string catalogName = CheckStringUserInput(Console.ReadLine());
            Catalog.CatalogCreate(catalogName);
        }

        public static void AddDiscToCatalogue()
        {
           Console.Clear();
           Console.WriteLine("Your catalog\n");
           Catalog.ShowCatalogName();

           do
            {
               Console.WriteLine("Enter disc:");
               
               var disk = CheckStringUserInput(Console.ReadLine()); 

               Disk.AddDisk(disk, Disk.diskCounter++);

            } while (EscPress("\nEnd adding disc? \nPress any key to continue or press ESC to end"));
             
        }

        public static void AddSongsToDisc()
        {
            if (Catalog.ListOfDisk.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Enter disc where you want to add song\nYou have that disks\n");

                Disk.ShowAllDisks();

                Console.WriteLine("Enter Number in what disk do you want write songs");

                //Check user input
                uint numOfDisk = CheckUintUserInput(Console.ReadLine());
                uint countDisc = 0;
                
                //Search needed disk and if we find add songs to it
                foreach (var disc in Catalog.ListOfDisk)
                {
                    if (disc.ID == numOfDisk)
                    {
                        countDisc++;
                        Console.Clear();
                        Console.WriteLine("Now you in disk called {0} \nEnter next format for add song\nNameOfArtist;NameOfSong", disc.Name);
                        do
                        {   
                            Console.WriteLine("Next song:");
                           // string nameOfSongs = CheckStringUserInput(Console.ReadLine());

                            string pattern = @"[0-9a-zA-zа-яёА-ЯЁ\s]{1,20}[;][0-9a-zA-zа-яёА-ЯЁ\s]{1,20}";
                            string nameOfSongs = CheckPatternFoSong(Console.ReadLine(), pattern,"Enter correct format to song\n ArtistName(max20);NameOfSong(max20)");

                            string[] temp = nameOfSongs.Split(';');
                            Song.AddSong(temp[0], temp[1], Song.songCounter++, disc.ID);

                        } while (UserChoise.EscPress("\nEnd adding songs? \nPress any key to continue or press ESC to end"));
                    }
                }
                //If number of Song not found print message
                if (countDisc == 0)
                {
                    Console.WriteLine("There is no number of disc which you Enter");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no disks to add songs");
            }
        }

        public static void ArtistSearch()
        {
            Console.Clear();
            Console.WriteLine("Enter artist");
            var artistName = CheckStringUserInput(Console.ReadLine());

            Song.FindArtist(artistName);
        }
        
        public static void AllCatalog()
        {
            Catalog.ShowAllInCatalogs();
        }

        public static void ShowDisk()
        {

            if (Catalog.ListOfDisk.Count>0)
            {

                Console.WriteLine("You have that disks");
                Disk.ShowAllDisks();

                Console.WriteLine("Enter Number of disc what do you want to see");

                // Check the correct input 
                uint numOfDisk = CheckUintUserInput(Console.ReadLine());
                uint countDisc = 0;

                foreach (var disc in Catalog.ListOfDisk)
                {
                    if (disc.ID == numOfDisk)
                    {
                        countDisc++;
                        Console.Clear();
                        Console.WriteLine("now you in disk called {0} \n", disc.Name);
                        foreach (var song in Disk.listOfSong)
                        {
                            if (song.DiskId == disc.ID)
                            {
                                Console.WriteLine(song.ToString());
                            }
                        }
                    }
                }
                //If number of Disc not found print message
                if (countDisc == 0)
                {
                    Console.WriteLine("There is no number of disc which you Enter");
                }
            }
            else {Console.WriteLine("There is no disk");}
        }

        public static void DeleteSong()
        {
            Console.Clear();
            if (Disk.listOfSong.Count > 0)
            {
                Song.ShowSongs();
                Console.WriteLine("Enter Number of songs what you want do delete");

                // Check the correct input 
                uint numOfSong = CheckUintUserInput(Console.ReadLine());
                uint countSong = 0;

                foreach (var song in Disk.listOfSong)
                {
                    if (song.ID == numOfSong)
                    {
                        countSong++;
                        Disk.listOfSong.Remove(song);
                        Console.WriteLine("Song Was Deleted");
                        break;
                    }
                }
                if (countSong == 0)
                {
                    Console.WriteLine("There is no number of song which you Enter");
                }
            }
            else
            {
                Console.WriteLine("There is no songs");
            }

        }

        public static void DeleteDisk()
        {
          
            Console.Clear();

            if (Catalog.ListOfDisk.Count > 0)
            {
                Disk.ShowAllDisks();

                Console.WriteLine("Enter Number of songs what you want do delete");

                // Check the correct input 
                uint numOfDisk = CheckUintUserInput(Console.ReadLine());
                uint countDisk = 0;

                foreach (var disk in Catalog.ListOfDisk)
                {
                    if (disk.ID == numOfDisk)
                    {
                        countDisk++;
                        for (int i = 0; i < Disk.listOfSong.Count; i++)
                        {
                            if (Disk.listOfSong[i].ID == disk.ID)
                            {
                                Disk.listOfSong.RemoveAt(Convert.ToInt16(Disk.listOfSong[i].ID));
                                i--;
                            }
                        }
                        Catalog.ListOfDisk.Remove(disk);
                        Console.WriteLine("\nDisk {0} was deleted",disk.Name);
                        break;
                    }
                }
                if (countDisk == 0)
                {
                    Console.WriteLine("There is no number of song which you Enter");
                }
            }
            else
            {
                Console.WriteLine("There is no disks");
            }

        }
        
        
        public static bool EscPress(string text)
        {
            var cki = new ConsoleKeyInfo();
            Console.WriteLine(text);
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return false;
            }
            else
                Console.Clear();

            return true;
        }

        public static uint CheckUintUserInput(string input)
        {
            uint someVar;
            while (!uint.TryParse(input, out someVar))
            {
                Console.WriteLine("Enter correct number");
                input = Console.ReadLine();
            }
            return someVar;
        }

        public static string CheckStringUserInput(string input)
        {
            while (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Enter not empty name");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string CheckPatternFoSong(string input,string pattern,string warningText)
        {
            

            while (!Regex.IsMatch(input,pattern))
            {
                Console.WriteLine(warningText);
                input = Console.ReadLine();
            }
            return input;
        }

    }
}
