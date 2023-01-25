using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
