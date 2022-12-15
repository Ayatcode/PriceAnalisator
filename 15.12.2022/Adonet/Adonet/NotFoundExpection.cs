using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet
{
    public class NotFoundExpection:Exception
    {
        public NotFoundExpection(string message) :base(message) 
        {
        }

    }
}
