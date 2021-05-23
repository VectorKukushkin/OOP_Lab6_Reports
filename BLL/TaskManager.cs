using OOP_Lab6_Reports.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    class TaskManager : ITaskManager
    {
        protected ITaskDataManager TaskDataManager = new TaskDataManager();

        public Task FindByID(string name)
        {
            return TaskDataManager.Get(name);
        }

        public HashSet<Task> FindByCreationTime(DateTime date)
        {
            HashSet<Task> tasks = new HashSet<Task>();
            foreach (Task task in TaskDataManager.GetAll())
            {
                if (task.CreationDate.Date == date.Date)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public HashSet<Task> FindByLastChange(DateTime date)
        {
            HashSet<Task> tasks = new HashSet<Task>();
            foreach (Task task in TaskDataManager.GetAll())
            {
                if (task.LastChangeDate.Date == date.Date)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public HashSet<Task> FindByEmployee(Employee employee)
        {
            HashSet<Task> tasks = new HashSet<Task>();
            if (employee != null)
            {
                foreach (Task task in TaskDataManager.GetAll())
                {
                    if (task.Employee == employee)
                    {
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }

        public HashSet<Task> FindByEmployeeChanges(Employee employee)
        {
            HashSet<Task> tasks = new HashSet<Task>();
            if (employee != null)
            {
                foreach (Task task in TaskDataManager.GetAll())
                {
                    if (task.GetAllEmployees().Contains(employee))
                    {
                        tasks.Add(task);
                    }
                }
            }
            return tasks;
        }

        public void CreateTask(string name, string description)
        {
            TaskDataManager.Add(new Task(name, description));
        }

        public void AddComment(Task task, Employee employee, string text)
        {
            if (employee != null && task != null)
            {
                task.AddComment(employee, text);
            }
        }

        public void SetEmployee(Task task, Employee employee)
        {
            if (employee != null && task != null)
            {
                task.Employee = employee;
            }
        }

        public void SetStatus(Task task, Status status)
        {
            if (task != null)
            {
                task.Status = status;
            }
        }

        public HashSet<Task> GetSubordinatesTasks(HashSet<Employee> subordinates)
        {
            HashSet<Task> tasks = new HashSet<Task>();
            foreach (Task task in TaskDataManager.GetAll())
            {
                if (subordinates.Contains(task.Employee))
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }
}
