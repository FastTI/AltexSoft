using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Task3_1
{
    /* В текстовом файле записаны вещественные числа 
    * (на каждой строчке - несколько, разделены несколькими пробелами) и что-то ещё.
    * Найти сумму чисел, игнорируя неверные лексемы.*/
    class Program
    {
        static void Main(string[] args)
        {
            string path = "DoubleNumbers.txt";  //путь к файлу в папке Debug
            string pattern = "-?[0-9]+,[0-9]+"; //паттерн для вещественных чисел
            char[] charForBreakdown = new char[] { ' ', '\n', '\r', '\t' }; //список символов-разделителей
            double sumOfDouble = 0; //сумма вещественных чисел


            using (StreamReader fileToRead = new StreamReader(path))
            {
                string[] fileR = fileToRead.ReadToEnd().Split(charForBreakdown);
                Console.WriteLine("Считанный файл");
                foreach (var ch in fileR)
                {
                    Console.Write(ch);
                }

                Console.WriteLine("\n\nВещественные числа из файла:");

                foreach (var b in fileR)
                {
                    if (b != "")
                    {
                        if (Regex.IsMatch(b, pattern))
                        {
                            Console.Write(b + "  ");
                            sumOfDouble += Convert.ToDouble(b);
                        }
                    }
                }
            }

            Console.WriteLine("\n\nСумма этих чисел\n" + sumOfDouble);
        }
    }
}
