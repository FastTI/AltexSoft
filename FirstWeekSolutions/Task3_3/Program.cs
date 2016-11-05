using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3
{
    /*Для данной директории рекурсивно выдать список её файлов и поддиректорий.*/
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"TestFolder\";
            
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                Console.WriteLine("List of folders and files by path " + dir.FullName);
                Console.WriteLine();

                GetDirFtFiles(dir);    
            }
            else
                Console.WriteLine("Directory not found");
         
            
        }

        //Recursive search subfolders and files by path
        private static void GetDirFtFiles(DirectoryInfo dir)
        {

            
                DirectoryInfo[] searchDirectory = dir.GetDirectories();
            
                foreach (var d in searchDirectory)
                {
                    Console.WriteLine("Folder: " + d.Name);
                    FileInfo[] searchFiles = d.GetFiles();
                    Console.WriteLine("\nFailes inside folder:");
                    if (searchFiles.Length > 0)
                    {
                        foreach (var f in searchFiles)
                        {
                            Console.WriteLine(new string(' ', 20) + f.Name);
                        }
                    }
                    else
                        Console.WriteLine(new string(' ', 20) + "In this folder no files");

                    Console.WriteLine(new string('-', 50));
                    //Рекурсивный вызов
                    GetDirFtFiles(d);
                }
            
            
        }
    }
}