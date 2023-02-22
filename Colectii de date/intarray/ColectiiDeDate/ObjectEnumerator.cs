using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    internal class ObjectEnumerator : IEnumerator
    {
        public ObjectArray obj;
        int position = -1;

        public  ObjectEnumerator(ObjectArray list)
        {
            obj = list;
        }

        public bool MoveNext()
        {
            position++;
            return position < obj.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        
        public object Current
        {
            get => obj[position];
        }
    }
}
