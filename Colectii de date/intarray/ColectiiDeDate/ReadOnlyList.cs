using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class ReadOnlyList<T> : IList<T>
    {
        private NotSupportedException ReadOnlyExeption()
        {
            return new NotSupportedException("Collection is read-only.");
        }

        private readonly IList<T> readOnlyList;

        public ReadOnlyList(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(Convert.ToString(list), "Array is null.");
            }

            readOnlyList = list;
        }

        public T this[int index]
        {
            get => readOnlyList[index];
            set => throw ReadOnlyExeption();
        }

        public bool IsReadOnly { get => true; }

        public int Count { get => readOnlyList.Count; }

        public virtual void Add(T obj) => throw ReadOnlyExeption();

        public int IndexOf(T obj) => readOnlyList.IndexOf(obj);

        public bool Contains(T obj) => readOnlyList.Contains(obj);

        public virtual void Insert(int index, T obj) => throw ReadOnlyExeption();

        public void Clear() => throw ReadOnlyExeption();

        public bool Remove(T obj) => throw ReadOnlyExeption();

        public void RemoveAt(int index) => throw ReadOnlyExeption();

        public IEnumerator<T> GetEnumerator() => readOnlyList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => readOnlyList.GetEnumerator();

        public void CopyTo(T[] array, int arrayIndex) => readOnlyList.CopyTo(array, arrayIndex);
    }
}
