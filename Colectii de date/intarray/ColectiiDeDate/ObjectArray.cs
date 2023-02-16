using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ColectiiDeDate
{
    public class ObjectArray
    {
        private object[] array;

        public ObjectArray()
        {
            array = new object[4];
        }

        public void Add(object obj) => Insert(Count, obj);

        public int Count { get; protected set; }

        public object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(object obj) => IndexOf(obj) != -1;

        public int IndexOf(object obj) => Array.IndexOf(array, obj, 0, Count);

        public void Insert(int index, object obj)
        {
            CheckLenght();
            ShiftRight(index);
            Count++;
            array[index] = obj;
        }

        public void Clear()
        {
            array = new object[4];
            Count = 0;
        }

        public void Remove(object obj)
        {
            var indexOfElement = IndexOf(obj);
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
