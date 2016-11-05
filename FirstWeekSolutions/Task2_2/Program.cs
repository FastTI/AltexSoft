using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{

    /* Для структуры Student создать массив. Отсортировать массив по полю FirstName.
                    a.	Используя перегруженный метод Sort(IComparer),реализовать сортировку по полю Age.*/

    //Sruct of Students using IComparable interface for sort by FirstName
    struct Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Faculty { get; set; }

       
        public int CompareTo(Student o)
        {
            if (o.FirstName != null)
            {
                return this.FirstName.CompareTo(o.FirstName);
            }
            else throw new Exception("none");
        }

        public override string ToString()
        {
            return String.Format("Student  {0}  {1}  \nFaculty: {2} \nAge: {3}\n", FirstName, LastName, Faculty, Age);
        }

    }
    
    //Comparator
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
            arrStudents[0] = new Student() { FirstName = "Vasiliy", LastName = "Vasiliev", Age = 20, Faculty = "Programming" };
            arrStudents[1] = new Student() { FirstName = "Petr", LastName = "Petrov", Age = 19, Faculty = "Economy" };
            arrStudents[2] = new Student() { FirstName = "Ivan", LastName = "Ivanov", Age = 18, Faculty = "Jurisprudence" };
            arrStudents[3] = new Student() { FirstName = "Anna", LastName = "Sidorova", Age = 20, Faculty = "Programming" };
            arrStudents[4] = new Student() { FirstName = "Igor", LastName = "Galushlo", Age = 19, Faculty = "Jurisprudence" };
            arrStudents[5] = new Student() { FirstName = "Denis", LastName = "Denisov", Age = 22, Faculty = "Programming" };
            arrStudents[6] = new Student() { FirstName = "Oleg", LastName = "Semenov", Age = 20, Faculty = "Jurisprudence" };
            arrStudents[7] = new Student() { FirstName = "Anton", LastName = "Smirnov", Age = 21, Faculty = "Programming" };


            //Sorting by FirstName with interface IComparable
            Array.Sort(arrStudents);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Sorting students by name:\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var arr in arrStudents)
            {
                Console.WriteLine(arr.ToString());
            }

            //Sorting by Age using comparator with interface IComparer 
            Array.Sort(arrStudents, new CompareByAge());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSorting students by Age\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var arr in arrStudents)
            {
                Console.WriteLine( arr.ToString());
        
            }
        }
    }
}
