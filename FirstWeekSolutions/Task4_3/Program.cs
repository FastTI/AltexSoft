using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_3
{
    /*Реализовать класс для организации работы со списком багажных ведомостей камеры хранения, 
     * включив следующие данные: ФИО пассажира, количество вещей, общий вес вещей. 
     * Вывести информацию о тех пассажирах, средний вес багажа которых превышает заданный, 
     * отсортировав их по количеству вещей, сданных в камеру хранения*/
    class Program
    {
        static void Main(string[] args)
        {
            List<BaggageList> listOfBagage = ListOfBaggageFromFile();
            float maxWeight = 0;

            do
            {
                var listOfOverBaggage = new List<BaggageList>();//список пассажиров с перевесом
                Console.WriteLine("Введите максимально допустимый вес:");
                
                    string input = Console.ReadLine();
                    while (!float.TryParse(input, out maxWeight) || float.Parse(input) <= 0)
                    {
                        Console.WriteLine("Введите корректый вес");
                        input = Console.ReadLine();
                    }

                    foreach (var baggage in listOfBagage)
                    {
                        if (baggage.ThingsWeight/baggage.NumOfThings > maxWeight)
                            listOfOverBaggage.Add(baggage);
                    }
                     
                    if (listOfOverBaggage.Count>0)
                    {
                        Console.WriteLine("Обнаружен перегруз: \n");
                        listOfOverBaggage.Sort(new BaggageList());
                        foreach (var bag in listOfOverBaggage)
                        {
                            Console.WriteLine("Имя: {0}\nФамилия: {1}\nОтчество: {2}\nКоличество вещей: {3}\nСредний вес {4:##.00}\n", bag.FirstName, bag.Surname, bag.Patronymic,bag.NumOfThings,bag.ThingsWeight / bag.NumOfThings);
                        }
                    }
                    else Console.WriteLine("Пассажиров с перегрузом не обнаружено");
 
            } while (EscPress());
        }

        //Багажная ведомость из файла
        static List<BaggageList> ListOfBaggageFromFile()
        {
            string fileOfBaggage = "BaggageList.txt";
            var listBg = new List<BaggageList>();
            using (var stream = new StreamReader(fileOfBaggage, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string[] lines = stream.ReadLine().Split(';');
                    listBg.Add(new BaggageList()
                    {
                      FirstName=lines[0],
                      Surname= lines[1],
                      Patronymic= lines[2],
                      NumOfThings = Convert.ToInt16(lines[3]),
                      ThingsWeight = Convert.ToSingle(lines[4])
                    }
                    );
                }

            }
            return listBg;
        }
        
        //Условие завершения цикла
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


    }
}
