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
            array = new int[0];
        }

        public void Add(int element)
        {
            Insert(array.Length, element);
        }

        public int Count()
        {
            return array.Length;
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
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
        }

        private void ShiftRight(int index)
        {
            for (int i = array.Length; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            Array.Resize(ref array, array.Length + 1);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < array.Length; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);
        }

    }
}

