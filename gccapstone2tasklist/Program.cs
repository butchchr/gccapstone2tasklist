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

            bool run = true;
            while (run)
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
                        logic.ListTasks();
                        int count = 1;
                        Console.WriteLine("Task#\t\tDone?\t\tDue Date\t\tTeam Member\t\tDescription");
                        foreach (Task task in logic.ListTasks())
                        {
                            Console.WriteLine($"{count}\t\t{task.IsDone}\t\t{task.DueDate.ToShortDateString()}\t\t{task.TeamMemberName}\t\t\t{task.Description}");
                            count++;
                        }
                    }
                    else if (userChoice == AddTaskChoice)
                    {
                        //AddTask - Enter all fields default to false for incompete, add to end of list
                        Console.WriteLine("ADD TASK\nTeam Member Name: ");
                        string newTeamName = Console.ReadLine();
                        Console.WriteLine("Task Description:");
                        string newTaskDescription = Console.ReadLine();
                        Console.WriteLine("Due Date (dd/mm/yyyy):");

                        DateTime newDueDate;
                        bool date1 = DateTime.TryParse(Console.ReadLine(), out newDueDate);

                        logic.AddTask(new Task
                        {
                            TeamMemberName = newTeamName,
                            Description = newTaskDescription,
                            DueDate = newDueDate
                        });
                    }
                    else if (userChoice == (DeleteTaskChoice))
                    {
                        //DeleteTask - ask which task, validate, display, 1 to end "confirm Y/N" return to main
                        int deleteTask = PromptAgain("DELETE TASK\nWhat task would you like to delete?:");
                        
                        if (IsPressedKey($"You want to delete task number {deleteTask}? y/n"))
                        {
                            logic.DeleteTask(deleteTask);
                        }
                        else
                        {
                            run = true;
                        }
                    }
                    else if (userChoice == MarkCompleteChoice)
                    {
                        //IsDone - ask which task, validate, display, Y changes and main, N main
                        int completeTask = PromptAgain("MARK COMPLETED\nWhat task would you like to mark completed");
                        if (IsPressedKey($"You want to complete task number {completeTask}? y/n"))
                        {
                            logic.MarkComplete(completeTask);
                        }
                        else
                        {
                             run = true;
                        }
                    }
                    else if (userChoice == QuitChoice)
                    {
                        if (IsPressedKey("Do you want to quit? y/n"))
                        {
                            Console.WriteLine("Have a Great Day!");
                            Console.ReadKey();
                            run = false;
                        }
                        else
                        {
                            run = true;
                        }
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
            }
        }

        static bool IsPressedKey(string Prompt)
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
        //prompt user for valid input and adds it to the list
        static int PromptAgain( string prompt)
        {
            bool runAgain = true;
            int completeTask;
            do
            {
                Console.WriteLine(prompt);
                runAgain = !int.TryParse(Console.ReadLine(), out completeTask);
            }
            while (runAgain);
            return completeTask;
        }
    }
}
