using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class List<T> : IEnumerable<T>
    {
        private T[] array;

        public List()
        {
            array = new T[4];
        }

        public virtual void Add(T obj)
        {
            CheckLength();
            array[Count++] = obj;
        }

        public int Count { get; protected set; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(T obj) => IndexOf(obj) != -1;

        public int IndexOf(T obj) => Array.IndexOf(array, obj, 0, Count);

        public virtual void Insert(int index, T obj)
        {
            CheckLength();
            ShiftRight(index);
            Count++;
            array[index] = obj;
        }

        public void Clear()
        {
            array = new T[4];
            Count = 0;
        }

        public void Remove(T obj)
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

        private void CheckLength()
        {
            if (Count == array.Length)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
