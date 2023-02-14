using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class IntArray
    {
        private int[] array;

	public IntArray()
        {
            array = new int[4];
        }

        public void Add(int element)
        {
            Insert(Count, element);
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(array, element, 0, Count) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element, 0 , Count);
        }

        public void Insert(int index, int element)
        {
            CheckLenght();
            ShiftRight(index);
            Count++;
            array[index] = element;
        }

        public void Clear()
        {
            array = new int[4];
            Count = 0;
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
            Count--;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void CheckLenght()
        {
            if (Count == array.Length)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }
    }
}

