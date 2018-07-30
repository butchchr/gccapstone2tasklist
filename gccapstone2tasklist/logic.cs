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
            int index = OffsetListId(userInput);
            if (IsValid(index))
            {
                return tasks[index];
            }
            return null;
        }

        public List<Task> ListTasks()
        {
            return tasks;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public bool DeleteTask(int userInput)
        {
            Task task = GetTask(userInput);
            if (task != null)
            {
                tasks.Remove(task);
                return true;
            }
            return false;
        }

        public bool MarkComplete(int userInput)
        {
            Task task = GetTask(userInput);
            if (task != null)
            {
                task.IsDone = true;
                return true;
            }
            return false;  
        }

        private bool IsValid(int taskIndex)
        {
            return taskIndex > 0 && taskIndex < tasks.Count; 
        }

        private int OffsetListId(int userInput)
        {
            return userInput - 1;
        }
    }
}
