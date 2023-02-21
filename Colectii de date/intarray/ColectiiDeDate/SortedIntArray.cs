using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class SortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                base[index] = value;
                SortArray();
            }
        }

        public override void Add(int element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            SortArray();
        }

        private void SortArray()
        {
            bool swapDone = false;
            for (int i = 0; i < Count - 1 && !swapDone; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (base[j] > base[j + 1])
                    {
                        Swap(j, j + 1);
                        swapDone = true;
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
