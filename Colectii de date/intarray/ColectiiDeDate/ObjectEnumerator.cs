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
        public List<int> obj;
        int position = -1;

        public  ObjectEnumerator(List<int> list)
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
            get => obj[position];
        }
    }
}
