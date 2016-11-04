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
            string[] arr;  //массив для хранения данных из файла

            WriteIntNumToFile(fileName, 10, 1, 10);

            //считываем данные в массив
            using (var readFile = new StreamReader(fileName))
            {
                arr = readFile.ReadToEnd().Split(' ');
            }

            Console.WriteLine("Числа записанные в файле");
            foreach (var s in arr)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();


            Console.WriteLine("Модифицированный файл с возведенными в квадрат элементами");
            using (StreamWriter fileStream = new StreamWriter(fileName, false))
            {
                foreach (var vr in arr)
                {
                    if (vr != "")
                    {
                        fileStream.Write(Convert.ToInt32(vr) * Convert.ToInt32(vr) + " ");
                        Console.Write(Convert.ToInt32(vr) * Convert.ToInt32(vr) + " ");
                    }
                }
            }
        }

        //запись в файл целых чисел в указанном диапазоне и количестве
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
