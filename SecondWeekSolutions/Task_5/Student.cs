using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Student:Person
    {
        public string Faculty { get; set; }
        public byte Course { get; set; }
        public int TeacherID { get; set; }

       //public Teacher TeacherOfStudent { get; set; }
        //public string TeacherOfStudent { get; set; }

        public Student()
        {
            
        }

        public Student(string name, string surname, byte age, string faculty, byte course,int teacherId) : base(name, surname, age)
        {
            this.Faculty = faculty;
            this.Course = course;
            this.TeacherID = teacherId;
        }


        public new virtual void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}\nFaculty: {3}\nCourse: {4}\n", Name, Surname, Age,Faculty,Course);
        }

        public override string ToString()
        {
            //return String.Format("Overrided ToString() Method from {0}", this.GetType().Name);
            return String.Format(base.ToString() + "\nFaculty: {0}\nCourse: {1}", Faculty, Course);
            //return String.Format("Name: {0}\nSurname: {1}\nAge: {2}\nFaculty: {3}\nCourse: {4}", Name, Surname, Age,Faculty, Course);

        }

        public override bool Equals(Object obj)
        {
            if (base.Equals(obj))
            {
                Student tempStudent = (Student) obj;
                if (this.Course == tempStudent.Course && this.Faculty == tempStudent.Faculty)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static void RandomStudent(Student[] studentArr)
        {
            if (studentArr.Length > 0)
            {
                Random rand = new Random();
                int tempStudent = rand.Next(0, studentArr.Length);
                studentArr[tempStudent].Print();
            }
            else
                Console.WriteLine("This array are empty");
        }

        public override object Clone(object objSource)
        {
            return base.Clone(objSource);
        }
    }


    
}
