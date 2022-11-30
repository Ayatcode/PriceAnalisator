using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customlist
{
    public class List<T>
    {
        public T[] arr;
        private static int count;
        public int Capacity { get; set; }
        public int Count { get => count; }

        public List()
        {
            Capacity = 0;
        }

        public List(int capacity)
        {
            Capacity = capacity;
        }

        public void Add(T item)
        {
            if (Capacity == 0)
            {
                Capacity = 2;
                Array.Resize(ref arr, Capacity);
                arr[0] = item;
                count++;
                return;
            }
            if (Count == Capacity)
            {
                Capacity = Capacity * 2;
                Array.Resize(ref arr, Capacity);
                arr[Capacity / 2] = item;
                count++;
                return;
            }
            arr[count] = item;
            count++;
        }
        public bool Exist(Predicate<T> macth)
        {
            foreach (var item in arr)
            {
                if (macth(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
