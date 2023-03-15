using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class List<T> : IList<T>
    {
        private T[] list;

        public List()
        {
            list = new T[4];
        }

        public virtual void Add(T obj)
        {
            CheckLength();
            list[Count++] = obj;
        }

        public int Count { get; protected set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public bool Contains(T obj) => IndexOf(obj) != -1;

        public int IndexOf(T obj) => Array.IndexOf(list, obj, 0, Count);

        public virtual void Insert(int index, T obj)
        {
            CheckLength();
            ShiftRight(index);
            Count++;
            list[index] = obj;
        }

        public void Clear()
        {
            list = new T[4];
            Count = 0;
        }

        public bool Remove(T obj)
        {
            if (Contains(obj))
            {
                ShiftLeft(IndexOf(obj));
                Count--;
                return true;
            }

            return false;
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
                list[i] = list[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
        }

        private void CheckLength()
        {
            if (Count == list.Length)
            {
                const int two = 2;
                Array.Resize(ref list, list.Length * two);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = list[i];
            }
        }
    }
}
