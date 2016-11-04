using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    /*Реализовать класс для организации работы со списком студентов группы, 
     * включив следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил. 
     * Вывести информацию о студентах, окончивших заданную школу, отсортировав их по году рождения.*/
    class Program
    {
        static void Main(string[] args)
        {
            var listOfStudents = new List<Students>()
              { 
                new Students(){FSP = "Андрей Андреев Андреевич",BirthDay = new DateTime(1988,10,23),Adress = "Пушкина 41", NumberOfSchool = 10},
                new Students(){FSP = "Петр Петров Петрович",BirthDay = new DateTime(1989,10,25),Adress = "Пушкина 23", NumberOfSchool = 10},
                new Students(){FSP = "Игорь Игорев Игоревич",BirthDay = new DateTime(1987,5,12),Adress = "Ленина 100", NumberOfSchool = 13},
                new Students(){FSP = "Денис Денисов Денисович",BirthDay = new DateTime(2000,6,1),Adress = "Калинина 4", NumberOfSchool = 13},
                new Students(){FSP = "Сергей Сергеев Сергеевич",BirthDay = new DateTime(2000,12,6),Adress = "Гагарина 7", NumberOfSchool = 13}
              };

            Console.Write("В данный момент в списке есть информация о выпускниках школ № ");

            //Сюда записывается информация о школах которые есть в списке
            List<int> numOfSchool = GetNumOfSchool(listOfStudents);

            foreach (var i in numOfSchool)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Graduates(listOfStudents);
        }

        //Формируется список номеров школ которые есть в списке студентов
        static List<int> GetNumOfSchool(List<Students> students)
        {
            var result = new List<int>();
            foreach (Students student in students)
            {
                if (!result.Contains(student.NumberOfSchool))
                    result.Add(student.NumberOfSchool);
            }
            return result;
        }

        //Выводит список выпускников сортированных по году рождения
        static void Graduates(List<Students> listOfStudents)
        {
            try
            {
                Console.Write("\nШкола № ");
                uint schoolNumber = Convert.ToUInt16(Console.ReadLine());

                //Сортируем список студентов
                listOfStudents.Sort(new Students());
                int countS = 0;//подсчет выпускников школы

                foreach (var list in listOfStudents)
                {
                    //Если заданная школа совпадает со школой из списка выводим информацию
                    if (list.NumberOfSchool == schoolNumber)
                    {
                        Console.WriteLine("\n{0} \n{1} \n{2} ", list.FSP, list.Adress,
                        list.BirthDay.ToShortDateString());
                        countS++;
                    }

                }
                if (countS > 0)
                    Console.WriteLine("\nВсего студентов окончивших Школу № {0} - {1}", schoolNumber, countS);
                else
                    Console.WriteLine("В спике нет студентов из этой школы");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ошибка\n          Возможно вы ввели не верный формат школы...");
            }
        }

    }
}
