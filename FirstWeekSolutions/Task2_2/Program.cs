using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{

    /* Для структуры Studentсоздать массив. Отсортировать массив по полю FirstName.
                    a.	Используя перегруженный метод Sort(IComparer),реализовать сортировку по полю Age.*/

    //Структура Students с реализацией интерфейса IComparable для сортировки по полю FirstName
    struct Student : IComparable<Student>
    {
        public string FirstName;
        public string LastName;
        public byte Age;
        public string Faculty;

        public int CompareTo(Student o)
        {
            if (o.FirstName != null)
            {
                return this.FirstName.CompareTo(o.FirstName);
            }
            else throw new Exception("none");
        }
    }

    //Компаратор
    struct CompareByAge : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            if (a.Age < b.Age)
                return -1;
            else if (a.Age > b.Age)
                return 1;
            else return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] arrStudents = new Student[8];
            arrStudents[0] = new Student() { FirstName = "Василий", LastName = "Васильев", Age = 20, Faculty = "Программирование" };
            arrStudents[1] = new Student() { FirstName = "Петр", LastName = "Петров", Age = 19, Faculty = "Экономика" };
            arrStudents[2] = new Student() { FirstName = "Иван", LastName = "Иванов", Age = 18, Faculty = "Право" };
            arrStudents[3] = new Student() { FirstName = "Петр", LastName = "Петров", Age = 20, Faculty = "Программирование" };
            arrStudents[4] = new Student() { FirstName = "Игорь", LastName = "Галушко", Age = 19, Faculty = "Право" };
            arrStudents[5] = new Student() { FirstName = "Денис", LastName = "Денисов", Age = 22, Faculty = "Программирование" };
            arrStudents[6] = new Student() { FirstName = "Олег", LastName = "Семенов", Age = 20, Faculty = "Право" };
            arrStudents[7] = new Student() { FirstName = "Антон", LastName = "Смирнов", Age = 21, Faculty = "Программирование" };


            //Сортировка по FirstName через реализацию интерфейса IComparable
            Array.Sort(arrStudents);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сортировка студентов по имени\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var arr in arrStudents)
            {
                Console.WriteLine(arr.FirstName);
            }

            //Сортировка по Age с помощью обьекта реализующего интерфейс IComparer
            Array.Sort(arrStudents, new CompareByAge());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сортировка студентов по возрасту\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var arr in arrStudents)
            {
                Console.WriteLine("Студент  {0}  {1}  \nФакультет: {2} \nВозраст: {3}\n", arr.FirstName, arr.LastName, arr.Faculty, arr.Age);
            }
        }
    }
}
