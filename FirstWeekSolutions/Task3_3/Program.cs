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
            string path = @"E:\AltexSoft Course\Courses-5wave";
            DirectoryInfo dir = new DirectoryInfo(path);

            Console.WriteLine("Список папок и файлов по пути " + dir.FullName);
            Console.WriteLine();

            GetDirFtFiles(dir);
        }

        //Рекурсивный поиск подпапок и файлов указанной директории
        private static void GetDirFtFiles(DirectoryInfo dir)
        {
            DirectoryInfo[] searchDirectory = dir.GetDirectories();
            try
            {

                foreach (var d in searchDirectory)
                {
                    Console.WriteLine("Папка: " + d.Name);
                    FileInfo[] searchFiles = d.GetFiles();
                    Console.WriteLine("\nФайлы внутри папки:");
                    if (searchFiles.Length > 0)
                    {
                        foreach (var f in searchFiles)
                        {
                            Console.WriteLine(new string(' ', 20) + f.Name);
                        }
                    }
                    else
                        Console.WriteLine(new string(' ', 20) + "В этой папке нет файлов");

                    Console.WriteLine(new string('-', 50));
                    //Рекурсивный вызов
                    GetDirFtFiles(d);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}