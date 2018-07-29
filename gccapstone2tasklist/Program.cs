using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gccapstone2tasklist
{
    class Program
    {
        static void Main(string[] args)
        {
            bool y = true;
            while (y)
            {
                Console.WriteLine("Welcome to the Task Manager!\n\t1. List tasks\n\t2. Add task\n\t3. Delete task\n\t4. Mark task complete\n\t5. Quit\nWhat would you like to do?");
                string dataFromUser = Console.ReadLine();

                int userChoice;
                bool num1 = int.TryParse(dataFromUser, out userChoice);

                if (!num1)
                {
                    Console.WriteLine("You did not enter a valid number");
                }

                //Task userTask = new Task();
                
                //Continue?
                bool invalid = true;
                while (invalid)
                {
                    Console.WriteLine("Continue? (y/n):");
                    ConsoleKeyInfo pressed = Console.ReadKey();
                    Console.WriteLine();
                    bool isY = pressed.Key == ConsoleKey.Y;
                    bool isN = pressed.Key == ConsoleKey.N;

                    invalid = !isY && !isN;
                    y = isY;
                }
            }
        }
    }
}
