using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    class TaskDataManager : ITaskDataManager
    {
        protected readonly Dictionary<string, Task> Tasks = new Dictionary<string, Task>();

        public HashSet<Task> GetAll()
        {
            HashSet<Task> tasks = new HashSet<Task>();
            foreach (Task task in Tasks.Values)
            {
                tasks.Add(task);
            }
            return tasks;
        }

        public Task Get(string name)
        {
            if (!Tasks.ContainsKey(name))
                throw new Exception("There is no the task in the list!");
            return Tasks[name];
        }

        public void Add(Task task)
        {
            if (Tasks.ContainsKey(task.Name))
                throw new Exception("The task is already contained in the list!");
            Tasks.Add(task.Name, task);
        }
    }
}
