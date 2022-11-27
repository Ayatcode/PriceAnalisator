using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Department
    {
        public string Name { get; set; }
        public int EmployeeLimit { get; set; }

        public Employee[] Employeearray;
        public Department()
        {
            Employeearray = new Employee[EmployeeLimit];

        }

        public Employee this[int index] 
        { 
            
            get 
            { 
                if(index>= Employeearray.Length || index<0) 
                { throw new CapacityLimitException("Limit");  }
                return Employeearray[index]; 
            } 
            set
            {
                Employeearray[index] = value;
            } 
        }
    }
}
