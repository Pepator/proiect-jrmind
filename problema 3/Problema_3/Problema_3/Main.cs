using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    class MainClass
    {
        static void Main(string[] args)
        {
            if (!(args.Length == 1))
            {
                Console.WriteLine("Please inser ONE argument !");
                return;
            }
                string text = File.ReadAllText(args[0]);
                var value = new Value();
                var match = value.Match(text);
                Console.WriteLine((match.Success() && match.RemainingText() == ""));
        }
    }
}
