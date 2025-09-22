using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment06Inheritance
{
    internal class Employee:Person
    {
        public Employee() { }
        public int  EmployeeId{ get; private set; }
        public double Salary {  get; private set; }
        public string JobTitle {  get; private set; }
        
        public Employee(int adhar,string name,int age,int employeeId, double salary, string jobTitle, string nationality) :base(adhar,name,age,nationality)
        {
            EmployeeId = employeeId;
            Salary = salary;
            JobTitle = jobTitle;
        }
        public void ShowEmployeeDetail()
        {
            BasicInfo();
            Console.WriteLine("Employee id: "+EmployeeId );
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("JobTitle: " + JobTitle);
        }

    }
}
