using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_oklib08_1_3_godtycklig_lonerevision
{
    class Program
    {
        private class ToSmallNumberException : Exception
        {

        }
        static void Main(string[] args)
        {
            Console.Title = Strings.Console_Title;

            do
            {
                Console.Clear();

                int numberOfSalarys = ReadInt(Strings.Number_Of_Salary_Prompt);

                int[] salariesArray = ReadSalaries(numberOfSalarys);

                ViewResult(salariesArray);
                
                ViewMessage(Strings.Continue_Prompt);
            } while (IsContinuing());
        }
        //Makes the Main loop until esc is pressed
        private static bool IsContinuing()
        {
            ConsoleKeyInfo esc;
            esc = Console.ReadKey();
            return esc.Key != ConsoleKey.Escape;
        }
        //Reads the number of salaries and the salaries
        private static int ReadInt(string prompt)
        {
            int readPrompt = 0;
            if ((Strings.Number_Of_Salary_Prompt == prompt))
	            {
		            while (true)
                    {
                        try
                        {
                            Console.Write(prompt);
                            readPrompt = int.Parse(Console.ReadLine());
                            if (readPrompt < 2)
                                throw new ToSmallNumberException(); 
                            break;
                        }
                        catch (ToSmallNumberException)
                        {
                            ViewMessage(Strings.Error_More_Than_Two_Message, ConsoleColor.Red);
                        }
                        catch (Exception)
                        {
                            ViewMessage(Strings.Error_Not_A_Number_Message, ConsoleColor.Red);
                        } 
                    }
                Console.WriteLine();
	            }

            if (prompt.StartsWith(Strings.Salary_Prompt))
            {
                while (true)
                {
                    try
                    {
                        Console.Write(prompt);
                        readPrompt = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        ViewMessage(Strings.Error_Not_A_Number_Message, ConsoleColor.Red);
                    }
                }
                Console.WriteLine();
            }

            return readPrompt;
        }
        //Creates an array of the salaries
        private static int[] ReadSalaries(int count)
        {
            string readIntSalary;

            int[] ReadSalariesArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                readIntSalary = (Strings.Salary_Prompt.Insert(Strings.Salary_Prompt.Length, String.Format("{0}: ", Convert.ToString(i + 1))));
                ReadSalariesArray[i] = ReadInt(readIntSalary);
            }
            return ReadSalariesArray;
        }
        //Displays the messages
        private static void ViewMessage(string message, ConsoleColor backgroundColor = ConsoleColor.Blue, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        //Calculates and displays the results
        private static void ViewResult(int[] salaries)
        {
            int count = 0;
            int rows = salaries.Length / 3;

            //If it's not possible to fit the salarys in 3 columns, then add another row
            if (salaries.Length % 3 != 0)
            {
                rows++;
            }

            Console.WriteLine(Strings.Line_Result);
            Console.WriteLine("{0}{1, 10:C0}", Strings.Median_Result.PadRight(18), MyExtensions.Median(salaries));
            Console.WriteLine("{0}{1, 10:C0}", Strings.Average_Result.PadRight(18), salaries.Average());
            Console.WriteLine("{0}{1, 10:C0}", Strings.Dispersion_Result.PadRight(18), MyExtensions.Dispersion(salaries));
            Console.WriteLine(Strings.Line_Result);

            if (count < salaries.Length)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (count < salaries.Length)
                        {
                            Console.Write("{0,8}", salaries[count]);
                            count++; 
                        }
                    }
                    Console.WriteLine();
                } 
            }
        }
    }
    static class MyExtensions
    {
        //Calculates wage dispersion
        public static int Dispersion(this int[] source)
        {
            return source.Max() - source.Min();

        }
        //Calculates median wage
        public static int Median(int[] source)
        {
            int place = 0;
            int median = 0;
            int[] salary = source.ToArray();

            Array.Sort(salary);
            if (2 == salary.Length)
            {
                median = (salary[0] + salary[1]) / 2;
            }
            else if (salary.Length % 2 != 0)
            {
                place = salary.Length / 2;
                median = salary[place];
            }
            else
            {
                place = salary.Length / 2;
                median = (salary[place] + salary[--place]) / 2;
            }
            return median;
        }
    }
}
