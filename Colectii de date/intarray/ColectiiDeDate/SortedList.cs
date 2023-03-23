using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public override T this[int index]
        {
            set
            {
                if (ElementAt(index - 1, value).CompareTo(value) <= 0 && value.CompareTo(ElementAt(index, value)) <= 0)
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(T element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, T element)
        {
            if (ElementAt(index - 1, element).CompareTo(element) <= 0 && element.CompareTo(ElementAt(index, element)) <= 0)
            {
                base.Insert(index, element);
            }
        }

        private T ElementAt(int index, T defaultValue)
        {
            return index < 0 || index >= Count ? defaultValue : base[index];
        }

        private void SortArray()
        {
            bool swapDone = false;
            for (int i = 0; i < Count - 1 && !swapDone; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (base[j].CompareTo(base[j + 1]) > 0)
                    {
                        T a = base[j];
                        T b = base[j + 1];
                        Swap(ref a, ref b);
                        base[j] = a;
                        base[j + 1] = b;
                        swapDone = true;
                    }
                }
            }
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
