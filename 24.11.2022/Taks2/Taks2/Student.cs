using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Taks2
{
    internal class Student:IDabs
    {
        private static int _id;
        private string _name;
        private string _surname;
        private string _group;

        public string Name {

            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else { throw new Exception("Bosdur"); }
                
            }
          
                
        }
        public string  Surname
        {
            get { return _surname; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _surname = value;
                }
                else { throw new Exception("Bosdur"); }

            }
        }
        public string group
        {
            get { return _group; }
            set
            {
                Groupname info= new Groupname();
                if (info.Check(value))
                {
                    _group = value;
                } 
                else { throw new Exception("Duzgun format deyil"); }

            }
        }

        public Student(string group,string Name,string Surname)
        {
            _id++;
            id = _id;
            _name =Name ;
            _surname=Surname;
            _group = group;

        }
        public void Getinfo()
        {
            Console.WriteLine($"id{id} name:{Name} surname:{Surname} group:{group}");
        }
    }
}
