using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gccapstone2tasklist
{
    class Logic
    {
        private List<Task> tasks = new List<Task>();

        public Task GetTask (int userInput)
        {
            return tasks[OffsetListId(userInput)];
        }

        public List<Task> ListTasks()
        {
            return tasks;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void DeleteTask(int userInput)
        {
            tasks.RemoveAt(OffsetListId(userInput));
        }

        public void MarkComplete(int userInput)
        {
            GetTask(OffsetListId(userInput)).IsDone = true;       
        }

        private bool IsValid(int taskIndex)
        {
            return tasks.Any(); 
        }

        private int OffsetListId(int userInput)
        {
            return userInput - 1;
        }
    }
}
