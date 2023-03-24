using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ColectiiDeDate
{
    public class List<T> : IList<T>
    {
        private readonly string errorMessageArgumentOutOfRangeException = "Index should be non-negative and equal or less than the size of the list.";
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
            get
            {
                CheckArgumentOutOfRangeExeption(index);

                return list[index];
            }
            set
            {
                CheckArgumentOutOfRangeExeption(index);

                list[index] = value;
            }
        }

        public bool Contains(T obj) => IndexOf(obj) != -1;

        public int IndexOf(T obj) => Array.IndexOf(list, obj, 0, Count);

        public virtual void Insert(int index, T obj)
        {
            CheckArgumentOutOfRangeExeption(index);
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
            var indexOfElement = IndexOf(obj);
            if (indexOfElement != -1)
            {
                RemoveAt(indexOfElement);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            CheckArgumentOutOfRangeExeption(index);
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
                throw new ArgumentNullException(Convert.ToString(arrayIndex), "Array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(arrayIndex), "Index out of range. Must be positive.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The number of elements to copy is greater than the available space in the array.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = list[i];
            }
        }

        private void CheckArgumentOutOfRangeExeption(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(index), errorMessageArgumentOutOfRangeException);
            }
        }
    }
}
