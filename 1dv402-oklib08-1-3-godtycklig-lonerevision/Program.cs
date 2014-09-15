using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_oklib08_1_3_godtycklig_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Strings.Console_Title;

            do
            {
                Console.Clear();
            } while (IsContinuing());
        }
        //Makes the Main loop until esc is pressed
        private static bool IsContinuing()
        {
            ConsoleKeyInfo esc;
            esc = Console.ReadKey();
            return esc.Key != ConsoleKey.Escape;
        }
        //private static int ReadInt(string prompt)
        //{

        //}
        //private static int[] ReadSalaries(int count)
        //{

        //}
        private static void ViewMessage(string message, ConsoleColor backgroundColor = ConsoleColor.Blue, ConsoleColor foregroundColor = ConsoleColor.White)
        {

        }
        private static void ViewResult(int[] salaries)
        {

        }
    }
    class MyExtensions
    {
        //public static int Dispersion(this int[] source)
        //{

        //}
        //private static int Median(this int[] source)
        //{

        //}
    }
}
