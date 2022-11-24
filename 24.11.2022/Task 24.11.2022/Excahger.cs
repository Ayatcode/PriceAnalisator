using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_24._11._2022
{
    
    internal class Excahger:currency1
    {
        public double res;


        public double Excange(int man,currency1.Currency  currency )
        {
            if(currency==currency1.Currency.USD)
            {
                 res = man * 0.59;
            }else if(currency==currency1.Currency.Eur){
                res = man * 0.53;
            }
            else if (currency == currency1.Currency.TRY)
            {
                res = man * 8.73;
            }
            else if (currency == currency1.Currency.Rub)
            {
                res = man * 52.21;
            }
            
            return res;
        }
    }
}
