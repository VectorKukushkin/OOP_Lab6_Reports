using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OOP_Lab6_Reports
{
    enum Status
    {
        Open,
        Active,
        Resolved
    };

    class Task
    {
        public Task(string name, string description)
        {
            Name = name;
            Description = description;
            status = Status.Open;
            CreationDate = DateTime.Now;
            AddChange(status);
        }

        public readonly string Name;
        public readonly string Description;

        private Employee employee;
        private Status status;

        public Employee Employee
        {
            set
            {
                if (status != Status.Resolved)
                {
                    if (employee != value)
                    {
                        employee = value;
                        AddChange(value);
                    }
                    else
                    {
                        throw new Exception("The task has already got this employee!");
                    }
                }
                else
                {
                    throw new Exception("The task has already resolved!");
                }
            }
            get
            {
                return employee;
            }
        }

        public Status Status
        {
            set
            {
                if (status < value)
                {
                    status = value;
                    AddChange(value);
                }
                else
                {
                    throw new Exception("The status can't be changed!");
                }
            }
            get
            {
                return status;
            }
        }

        private void AddChange()
        {
            LastChangeDate = DateTime.Now;
        }

        private void AddChange(Status status)
        {
            statusChanges.Add((DateTime.Now, status));
            AddChange();
        }

        private void AddChange(Employee employee)
        {
            employeeChanges.Add((DateTime.Now, employee));
            AddChange();
        }

        public void AddComment(Employee employee, string text)
        {
            if (status != Status.Resolved)
            {
                comments.Add((DateTime.Now, employee, text));
                AddChange();
            }
            else
            {
                throw new Exception("The task has already resolved!");
            }
        }

        public HashSet<Employee> GetAllEmployees()
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach ((DateTime Date, Employee Employee) employeeChange in employeeChanges)
            {
                employees.Add(employeeChange.Employee);
            }
            foreach ((DateTime Date, Employee Employee, string Text) comment in comments)
            {
                employees.Add(comment.Employee);
            }
            return employees;
        }

        public readonly DateTime CreationDate;

        public DateTime LastChangeDate { get; private set; }

        private readonly List<(DateTime Date, Status Status)> statusChanges = new List<(DateTime, Status)>();
        private readonly List<(DateTime Date, Employee Employee)> employeeChanges = new List<(DateTime, Employee)>();
        private readonly List<(DateTime Date, Employee Employee, string Text)> comments = new List<(DateTime, Employee, string)>();

        public ReadOnlyCollection<(DateTime Date, Status Status)> StatusChanges
        {
            get 
            {
                return statusChanges.AsReadOnly();
            }
        }

        public ReadOnlyCollection<(DateTime Date, Employee Employee)> EmployeeChanges
        {
            get
            {
                return employeeChanges.AsReadOnly();
            }
        }

        public ReadOnlyCollection<(DateTime Date, Employee Employee, string Text)> Comments
        {
            get
            {
                return comments.AsReadOnly();
            }
        }
    }
}
