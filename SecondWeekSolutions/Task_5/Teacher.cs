using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Teacher:Person
    {
        public int ID { get; set; }
        public string Subject {get; set; }
        public string Rank { get; set; }

        public List<Student> StudentsOfTeacher = new List<Student>();

        public Teacher()
        {
            
        }
        public Teacher(int id, string name, string surname, byte age,string subject, string rank ) : base(name, surname, age)
        {
            this.Subject = subject;
            this.Rank = rank;
            this.ID = id;
        }

        public override void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}\nSubject: {3}\nRank: {4}\n",Name,Surname,Age,Subject,Rank);
        }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format(base.ToString() + "\nSubject: {0}\nRank: {1}",Subject,Rank);
        }
        public override bool Equals(Object obj)
        {
            if (base.Equals(obj))
            {
                Teacher tempTeacher = (Teacher)obj;
                if (this.Subject == tempTeacher.Subject && this.Rank == tempTeacher.Rank)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static void RandomTeacher(Teacher[] teacherArr)
        {
            //if (teacherArr.Length > 0)
            //{
            //    Random rand = new Random();
            //    int tempTeacher = rand.Next(0, teacherArr.Length);
            //    teacherArr[tempTeacher].Print();
            //}
            //else
            //    Console.WriteLine("This array are empty");

            
           
        }

        public override object Clone(object objSource)
        {
            return base.Clone(objSource);
        }

  

    }
}
