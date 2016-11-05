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
            string path = "DoubleNumbers.txt";  //path to file in Debug folder
            string pattern = "-?[0-9]+,[0-9]+"; //pattern for check for double
            char[] charForBreakdown = new char[] { ' ', '\n', '\r', '\t' }; //list of separators
            double sumOfDouble = 0; //sum of double num

            if (File.Exists(path) && File.ReadAllLines(path).Length > 0)
            {
                using (StreamReader fileToRead = new StreamReader(path))
                {
                    string[] fileR = fileToRead.ReadToEnd().Split(charForBreakdown);
                    Console.WriteLine("Read file");
                    foreach (var ch in fileR)
                    {
                        Console.Write(ch+" ");
                    }

                    Console.WriteLine("\n\nDouble numbers from file:");

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

                Console.WriteLine("\n\nSum of this numbers\n" + sumOfDouble);         
            }
            else
                Console.WriteLine("File \'{0}\' not found or it's empty\nCheck the path to the file or its contents", path);
            
        }
    }
}
