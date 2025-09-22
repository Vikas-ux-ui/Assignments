using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment06Inheritance
{

    internal class Mentor:Employee
    {
        private string Subject
        {
            get; set;
        }
        
        public Mentor(int adhar,string name, int age, string subject,  int employeeId, double salary, string jobTitle , string nationality) : base ( adhar,name, age, employeeId, salary, jobTitle, nationality)
        { 
            Subject = subject;
        }
        public Mentor() { }
        public void MentorDetail()
        {
            BasicInfo();
            Console.WriteLine($"{Name } Teaches {Subject}");

        }


    }
}
