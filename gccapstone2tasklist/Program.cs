using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gccapstone2tasklist
{
    class Program
    {
        const int ListTaskChoice = 1;
        const int AddTaskChoice = 2;
        const int DeleteTaskChoice = 3;
        const int MarkCompleteChoice = 4;
        const int QuitChoice = 5;

        static void Main(string[] args)
        {
            Logic logic = new Logic();

            bool y = true;
            while (y)
            {
                Console.WriteLine($"Welcome to the Task Manager!\n\t{ListTaskChoice}. List tasks\n\t{AddTaskChoice}. Add task\n\t{DeleteTaskChoice}. Delete task\n\t{MarkCompleteChoice}. Mark task complete\n\t{QuitChoice}. Quit\nWhat would you like to do?");
                string dataFromUser = Console.ReadLine();

                int userChoice;
                bool num1 = int.TryParse(dataFromUser, out userChoice);
                
                if (num1)
                {
                    if (userChoice == ListTaskChoice)
                    {
                        //ListTasks - Display tasks tabbed and display task number
                        Console.WriteLine(logic.ListTasks());
                    }
                    else if (userChoice == AddTaskChoice)
                    {
                        //AddTask - Enter all fields default to false for incompete, add to end of list
                        //Console.WriteLine(logic.AddTask());
                    }
                    else if (userChoice == (DeleteTaskChoice))
                    {
                        //DeleteTask - ask which task, validate, display, 1 to end "confirm Y/N" return to main
                        //Console.WriteLine(logic.DeleteTask());
                    }
                    else if (userChoice == MarkCompleteChoice)
                    {
                        //IsDone - ask which task, validate, display, Y changes and main, N main
                        //Console.WriteLine(logic.MarkComplete());
                    }
                    else if (userChoice == QuitChoice)
                    {
                        //Quit - confirm Y = quit N = main menu

                    }
                    else
                    {
                        Console.WriteLine("You did not enter a valid number between 1 and 5");
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a valid input");
                }
                IsYorN(Console.ReadKey(), "Continue? (y/n)");
            }
        }

        static bool IsYorN(ConsoleKeyInfo YN, string Prompt)
        {
            bool invalid = true;
            while (invalid)
            {
                Console.WriteLine(Prompt);
                ConsoleKeyInfo pressed = Console.ReadKey();
                Console.WriteLine();
                bool isY = pressed.Key == ConsoleKey.Y;
                bool isN = pressed.Key == ConsoleKey.N;

                invalid = !isY && !isN;
                return true;
            }
            return false;
        }
    }
}
