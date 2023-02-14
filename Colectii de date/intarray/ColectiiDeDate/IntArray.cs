using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class IntArray
    {
        int count = 0;
        private int[] array;

	public IntArray()
        {
            array = new int[4];
        }

        public void Add(int element)
        {
            Insert(count, element);
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array.SetValue(element, index);
        }

        public bool Contains(int element)
        {
            foreach (int i in array)
            {
                if (i == element)
                {
                    return true;
                }

            }

            return false;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            CheckLenght();
            ShiftRight(index);
            count++;
            array[index] = element;
        }

        public void Clear()
        {
            array = new int[4];
            count = 0;
        }

        public void Remove(int element)
        {
            var indexOfElement = IndexOf(element);
            if (indexOfElement != -1)
            {
                RemoveAt(indexOfElement);
            }
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            count--;
        }

        private void ShiftRight(int index)
        {
            for (int i = count - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void CheckLenght()
        {
            if (count == array.Length)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }
    }
}

