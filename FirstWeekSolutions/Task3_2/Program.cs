using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3_2
{
    /*Создать типизированный файл целых, затем модифицировать его, возведя все элементы в квадрат.*/
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Test.dat";
            string[] arrNumsFromFile;  //array for data from file


            if (File.Exists(fileName) && File.ReadAllLines(fileName).Length > 0)
            {
                WriteIntNumToFile(fileName, 10, 1, 10);

                //Reading data from file
                using (var readFile = new StreamReader(fileName))
                {
                    arrNumsFromFile = readFile.ReadToEnd().Split(' ');
                }

                Console.WriteLine("Numbers wrote to file");
                foreach (var s in arrNumsFromFile)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();


                Console.WriteLine("Modified file with squaring elements");
                using (StreamWriter fileStream = new StreamWriter(fileName, false))
                {
                    foreach (var vr in arrNumsFromFile)
                    {
                        if (vr != "")
                        {
                            fileStream.Write(Convert.ToInt32(vr) * Convert.ToInt32(vr) + " ");
                            Console.Write(Convert.ToInt32(vr) * Convert.ToInt32(vr) + " ");
                        }
                    }
                }
            }
            else
                Console.WriteLine("File \'{0}\' not found or it's empty\nCheck the path to the file or its contents", fileName);
        }

        //Write Random int numbers to file
        static void WriteIntNumToFile(string path, int countOfNum, int from, int to)
        {
            Random rand = new Random();

            using (var fileStream = new StreamWriter(path))
            {
                for (int i = 0; i < countOfNum; i++)
                {
                    fileStream.Write(rand.Next(from, to) + " ");
                }
            }
        }


    }
}
