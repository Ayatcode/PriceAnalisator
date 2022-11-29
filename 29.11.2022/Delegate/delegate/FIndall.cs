using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Fidndall<T>
{
    private T[] _arr; 


    public void New_array(T []arr, Check Func)
    {
        _arr= new T[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (Func(arr[i]))
            {
                _arr[i] = arr[i];
            }


        }
        foreach (var item in _arr)
        {
            Console.WriteLine(item);
        }
    }

    public delegate bool Check(T arr);


}

