namespace IntArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] studentGrades = { 10, 4, 5, 10, 7 };
            string studentPosition = Console.ReadLine();

            try
            {
                int position = int.Parse(studentPosition);
                Console.WriteLine("You have selected student position : {0}", studentPosition);

                try
                {
                    Console.WriteLine("Grade for student position {0} is {1}", position, studentGrades[position]);
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("Student position not found");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Unable to parse : {0}", studentPosition);
                Console.WriteLine("Please enter valid position");
            }
        }
    }
}