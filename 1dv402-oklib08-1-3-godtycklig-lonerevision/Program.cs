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

                foreach (int item in salariesArray)
                {
                    Console.WriteLine(item);
                }
                
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
                        if (readPrompt < 10000)
                            throw new ToSmallNumberException();
                        break;
                    }
                    catch (ToSmallNumberException)
                    {
                        ViewMessage(Strings.Error_Higher_Salary, ConsoleColor.Red);
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

        private static void ViewResult(int[] salaries)
        {

        }
    }
    //class MyExtensions
    //{
    //    public static int Dispersion(this int[] source)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    private static int Median(this int[] source)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
