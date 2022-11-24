using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks2
{
    internal class Groupname
    {   
        public static bool Uppercase=false;
        public static bool Isnum=true;

        public bool Check(string name)
        {
            if (name.Length == 5)
            {
                if (char.IsUpper(name[0]) && char.IsUpper(name[1]))
                {
                    Uppercase= true;
                }
                for (int i = 2; i < name.Length; i++)
                {
                    if (!char.IsNumber(name[i]))
                    {
                        Isnum=false;
                    }
                }
                if(Uppercase && Isnum)
                {
                    return true;
                }
                

                
            }
            return false;
        }
    }
}
