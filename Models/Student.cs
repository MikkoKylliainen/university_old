using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace university.Models
{
    public class Student
    {
        public Student(){}
        public Student(int id, string fn, string ln) {
            this.id=id;
            this.fname=fn;
            this.lname=ln;
        }
        public int id { get; set; }
        public string fname { get; set; } 
        public string lname { get; set; }               
        public string GetAllStudents () {
            string result = "";

            List<Student> studentsCollection=new List<Student>();
            studentsCollection.Add(new Student(1,"Jim","Jones"));
            studentsCollection.Add(new Student(2,"Lisa","Smith"));
            studentsCollection.Add(new Student(3,"Ann","Smith"));

            foreach (Student stu in studentsCollection) {
                result += stu.id + " " + stu.fname + " " + stu.lname + "\n";
            }
            return result;                    
        }

        public string GetOneStudent (int id) {
            string result = "";

            List<Student> studentsCollection=new List<Student>();
            studentsCollection.Add(new Student(1,"Jim","Jones"));
            studentsCollection.Add(new Student(2,"Lisa","Smith"));
            studentsCollection.Add(new Student(3,"Ann","Smith"));

            foreach (Student stu in studentsCollection) {
                if (stu.id == id) {
                    result += stu.id + " " + stu.fname + " " + stu.lname + "\n";
                }
            }
            return result;    
        }
    }
}