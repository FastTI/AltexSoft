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
            const string pattern = "[0-9]{4}"; //ограничения на вводимые символы
            
            do
            {
                    Console.WriteLine("Введите год выпуска авто");
                    string yearOfCar = Console.ReadLine();
                    if (Regex.IsMatch(yearOfCar, pattern))
                    {
                        if (Convert.ToInt16(yearOfCar) < DateTime.Now.Year)
                        {
                            var listEarlyCar = new List<SheetOfCar>();
                            foreach (var car in listOfCar)
                            {
                                if (car.YearOfBuy < Convert.ToInt16(yearOfCar))
                                    listEarlyCar.Add(car);

                            }
                                if (listEarlyCar.Count > 0)
                                {
                                    Console.WriteLine("Список автомобилей выпущеных раньше {0} года\n", yearOfCar);
                                    PrintResultList(listEarlyCar);
                                }
                                else
                                    Console.WriteLine("В списке нет машин выпущеных раньше {0} года", yearOfCar);
                        }
                        else
                        {
                            Console.WriteLine("Год покупки авто не может превышать текущий");
                        }   
                    }
                    else
                    {
                        Console.WriteLine(
                            "Введите верный формат года. Четыре цифры");
                    }
                
            } while (EscPress());

        }

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

        static bool EscPress()
        {
            var cki = new ConsoleKeyInfo();
            Console.WriteLine("\nЗакончить операцию?\nДля продолжения нажмите любую клавишу/Для завершения нажмите Esc");
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

        static void PrintResultList(List<SheetOfCar> list )
        {
            list.Sort(new ComparerSheetOfCar());
          
            foreach (var earlyCar in list)
            {
                Console.WriteLine(
                    "Модель авто: {0}\nНомерной знак: {1}\nФамилия владельца: {2}\nГод покупки: {3}\nПробег: {4} км\n"
                    , earlyCar.Model, earlyCar.NumOfCar, earlyCar.Surname, earlyCar.YearOfBuy,
                    earlyCar.Mileage);
            }
        }
    }
}
