using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee : IPerson
    {
        public string Name { get; set ; }
        public int Age { get ; set; }
        public int Salary { get; set; }
        public int id { get;  }
        private static int _id;

        public Employee(string name,int age,int salary) 
        { 
            Name = name;
            Age = age;
            Salary = salary;
            _id++;
            id = _id;
        }

        public string Showinfo()
        {
            return $" ID:{id},Name:{Name},Age{Age},Salary:{Salary}";

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
