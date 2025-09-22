using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//controller helper biz
namespace Assignment06Inheritance
{
    internal class Person
    {
        public Person() { }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int AdharId {  get; private set; }

        public string Nationality { get; private set; }
        public Person(int adhar,string name, int age, string nationality)
        {
            Name = name;
            Age = age;
            AdharId = adhar;
            Nationality = nationality;
        }
        public void BasicInfo()
        {
            Console.WriteLine("Name :"+Name);
            Console.WriteLine("Age :"+Age);
            Console.WriteLine("Nationality"+ Nationality);
            Console.WriteLine("Adhar"+AdharId);
        }
        

    }
}
