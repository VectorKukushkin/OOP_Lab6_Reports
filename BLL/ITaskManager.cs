using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    interface ITaskManager
    {
        Task FindByID(string name);

        HashSet<Task> FindByCreationTime(DateTime date);

        HashSet<Task> FindByLastChange(DateTime date);

        HashSet<Task> FindByEmployee(Employee employee);

        HashSet<Task> FindByEmployeeChanges(Employee employee);

        void CreateTask(string name, string description);

        void AddComment(Task task, Employee employee, string text);

        void SetEmployee(Task task, Employee employee);

        void SetStatus(Task task, Status status);

        HashSet<Task> GetSubordinatesTasks(HashSet<Employee> subordinates);
    }
}
