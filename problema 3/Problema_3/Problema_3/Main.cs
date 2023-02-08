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
            if (args.Length == 1)
            {
                string text = File.ReadAllText(args[0]);
                var value = new Value();
                var match = value.Match(text);

                if (match.Success() && match.RemainingText() == "")
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
