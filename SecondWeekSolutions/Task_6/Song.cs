using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Song
    {
        public static uint songCounter = 0;

        public string Artist { get; set; }

        public string NameOfSong { get; set; }

        public  uint  ID { get; set; }

        public  uint DiskId { get; set; }

        public Song()
        {
            
        }

        public Song(string artist, string nameOfSong,uint id, uint diskId)
        {
            this.Artist = artist;
            this.NameOfSong = nameOfSong;
            this.ID = id;
            this.DiskId = diskId;
        }

        public static void ShowSongs()
        {
            foreach (var song in Disk.listOfSong)
            {
                Console.WriteLine(song.ToString());
            }

        }

        public static void AddSong(string artist,string nameOfSong,uint id, uint diskId)
        {
            Disk.listOfSong.Add(new Song(artist,nameOfSong,id,diskId));
        }

        public static void FindArtist(string artist)
        {
            uint countArt = 0;
            if (Disk.listOfSong.Count>0)
            {
                foreach (var song in Disk.listOfSong)
                {
                    if (song.Artist == artist)
                    {
                        Console.WriteLine("{0}-{1}",song.Artist,song.NameOfSong);
                        countArt++;
                    }
                }
                if (countArt == 0)
                {
                    Console.WriteLine("There is no Artist with this name");
                }
            }
            else Console.WriteLine("You do not have any song on your catalog");
           
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}-{2}", ID, Artist,NameOfSong);
        }
    }
}
