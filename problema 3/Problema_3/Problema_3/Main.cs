using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    class MainClass
    {
        static void Main()
        {
            Console.WriteLine("Enter text file path: ");

            string text = File.ReadAllText(Console.ReadLine());
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

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
