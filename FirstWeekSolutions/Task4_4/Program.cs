using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4_4
{
    /*Реализовать класс для организации работы со списком автомобильных ведомостей, 
     * включив следующие данные: марка автомобиля, номер автомобиля, 
     * фамилия его владельца,  год приобретения, пробег. 
     * Вывести информацию об автомобилях, выпущенных ранее определенного года, отсортировав их по пробегу.*/
    class Program
    {
        static void Main(string[] args)
        {
            List<SheetOfCar> listOfCar = ListOfCarFromFile();
            const string pattern = "[0-9]{4}"; //pattern for 4 numbers enter
            
            do
            {
                    Console.WriteLine("Enter Year of Car production");
                    string yearOfCar = Console.ReadLine();
                    if (Regex.IsMatch(yearOfCar, pattern))
                    {
                        if (Convert.ToInt16(yearOfCar) <= DateTime.Now.Year)
                        {
                            var listEarlyCar = new List<SheetOfCar>();
                            foreach (var car in listOfCar)
                            {
                                if (car.YearOfBuy < Convert.ToInt16(yearOfCar))
                                    listEarlyCar.Add(car);

                            }
                                if (listEarlyCar.Count > 0)
                                {
                                    Console.WriteLine("List of car issued previously {0} year\n", yearOfCar);
                                   listEarlyCar.Sort(new ComparerSheetOfCar());
                                    foreach (var sheetOfCar in listEarlyCar)
                                    {
                                        Console.WriteLine(sheetOfCar.ToString());
                                    }

                                }
                                else
                                    Console.WriteLine("In list no one car issued previously {0} year", yearOfCar);
                        }
                        else
                            Console.WriteLine("Year of by car can not exceed current year");
                    }
                    else
                        Console.WriteLine("Enter correct format of year");
                    
                
            } while (EscPress());

        }

        //List of car from file
        static List<SheetOfCar> ListOfCarFromFile()
        {
            string fileOfCar = "CarList.txt";
            var listBg = new List<SheetOfCar>();
            using (var stream = new StreamReader(fileOfCar, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string[] lines = stream.ReadLine().Split(';');
                    listBg.Add(new SheetOfCar()
                    {
                       Model = lines[0],
                       NumOfCar = lines[1],
                       Surname = lines[2],
                       YearOfBuy = Convert.ToUInt16(lines[3]),
                       Mileage = Convert.ToSingle(lines[4])
                    }
                    );
                }

            }
            return listBg;
        }
        //For end of cycle
        static bool EscPress()
        {
            var cki = new ConsoleKeyInfo();
            Console.WriteLine("\nFinish operation?\nPress any key to continue/Press Esc to quit");
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

    }
}
