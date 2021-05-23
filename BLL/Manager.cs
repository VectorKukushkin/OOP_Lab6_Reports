using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    class Manager : IManager
    {
        public Manager()
        {
            ReportManagers.Add(new ReportManager());
        }

        protected readonly IEmployeeManager EmployeeManager = new EmployeeManager();
        protected readonly ITaskManager TaskManager = new TaskManager();
        protected readonly List<IReportManager> ReportManagers = new List<IReportManager>();

        private IReportManager ReportManager
        {
            get
            {
                return ReportManagers[^1];
            }
        }

        public uint SprintNumber
        {
            get
            {
                return (uint)ReportManagers.Count;
            }
        }

        // employees

        public Employee GetEmployee(string employee)
        {
            return EmployeeManager.GetEmployee(employee);
        }

        public void AddEmployee(string employee)
        {
            EmployeeManager.AddEmployee(employee);
        }

        public void AddEmployee(string employee, string director)
        {
            EmployeeManager.AddEmployee(employee, EmployeeManager.GetEmployee(director));
        }

        public string GetDirector(string employee)
        {
            return EmployeeManager.GetDirector(EmployeeManager.GetEmployee(employee)).Name;
        }

        public void SetDirector(string employee, string director)
        {
            EmployeeManager.SetDirector(EmployeeManager.GetEmployee(employee), EmployeeManager.GetEmployee(director));
        }

        public HashSet<Employee> GetSubordinates(string employee)
        {
            return EmployeeManager.GetSubordinates(EmployeeManager.GetEmployee(employee));
        }

        // tasks

        public string GetDescription(string task)
        {
            return TaskManager.FindByID(task).Description;
        }

        public HashSet<Task> FindByCreationTime(DateTime date)
        {
            return TaskManager.FindByCreationTime(date);
        }

        public HashSet<Task> FindByLastChange(DateTime date)
        {
            return TaskManager.FindByLastChange(date);
        }

        public HashSet<Task> FindByEmployee(string employee)
        {
            return TaskManager.FindByEmployee(EmployeeManager.GetEmployee(employee));
        }

        public HashSet<Task> FindByEmployeeChanges(string employee)
        {
            return TaskManager.FindByEmployeeChanges(EmployeeManager.GetEmployee(employee));
        }

        public void CreateTask(string name, string description)
        {
            TaskManager.CreateTask(name, description);
        }

        public void AddComment(string task, string employee, string text)
        {
            TaskManager.AddComment(TaskManager.FindByID(task), EmployeeManager.GetEmployee(employee), text);
        }

        public void SetEmployee(string task, string employee)
        {
            TaskManager.SetEmployee(TaskManager.FindByID(task), EmployeeManager.GetEmployee(employee));
        }

        public void SetStatus(string task, Status status)
        {
            Task t = TaskManager.FindByID(task);
            if (t != null)
            {
                if (t.Status != Status.Resolved && status == Status.Resolved)
                {
                    ReportManager.AddTask(t.Employee, t);
                }
                TaskManager.SetStatus(t, status);
            }
        }

        public HashSet<Task> GetSubordinatesTasks(string employee)
        {
            return TaskManager.GetSubordinatesTasks(EmployeeManager.GetSubordinates(EmployeeManager.GetEmployee(employee)));
        }

        // reports

        public string GetReportText(uint sprint, string employee, DateTime date)
        {
            if (sprint >= ReportManagers.Count)
                throw new Exception("There is no this sprint!");
            return ReportManagers[(int)sprint].GetReportText(EmployeeManager.GetEmployee(employee), date);

        }

        public string GetReportText(string employee, DateTime date)
        {
            return ReportManager.GetReportText(EmployeeManager.GetEmployee(employee), date);
        }

        public string GetReportText(string employee)
        {
            return GetReportText(employee, DateTime.Now);
        }

        public void SetReportText(string employee, string text)
        {
            ReportManager.SetReportText(EmployeeManager.GetEmployee(employee), text);
        }

        public string GetFinalReportText(uint sprint, string employee)
        {
            if (sprint < ReportManagers.Count)
                throw new Exception("There is no this sprint!");
            return ReportManagers[(int)sprint].GetFinalReportText(EmployeeManager.GetEmployee(employee));
        }

        public string GetFinalReportText(string employee)
        {
            return ReportManager.GetFinalReportText(EmployeeManager.GetEmployee(employee));
        }

        public void SetFinalReportText(string employee, string text)
        {
            ReportManager.SetFinalReportText(EmployeeManager.GetEmployee(employee), text);
        }

        public Report GetReport(uint sprint, string employee, DateTime date)
        {
            if (sprint >= SprintNumber)
                throw new Exception("There is no this sprint!");
            return ReportManagers[(int)sprint].GetReport(EmployeeManager.GetEmployee(employee), date);
        }

        public Report GetReport(string employee, DateTime date)
        {
            return ReportManager.GetReport(EmployeeManager.GetEmployee(employee), date);
        }

        public FinalReport GetFinalReport(uint sprint, string employee)
        {
            if (sprint >= SprintNumber)
                throw new Exception("There is no this sprint!");
            return ReportManagers[(int)sprint].GetFinalReport(EmployeeManager.GetEmployee(employee));
        }

        public FinalReport GetFinalReport(string employee)
        {
            return ReportManager.GetFinalReport(EmployeeManager.GetEmployee(employee));
        }

        public void FinishFinalReport(string employee)
        {
            ReportManager.AddReports(EmployeeManager.GetEmployee(employee), EmployeeManager.GetSubordinates(EmployeeManager.GetEmployee(employee)));
            ReportManager.FinishFinalReport(EmployeeManager.GetEmployee(employee));
        }

        public void FinishSprint()
        {
            HashSet<Employee> employees = EmployeeManager.GetAllEmployees();
            foreach (Employee employee in employees)
            {
                ReportManager.AddReports(employee, EmployeeManager.GetSubordinates(employee));
                ReportManager.FinishFinalReport(employee);
            }
            ReportManagers.Add(new ReportManager());
        }
    }
}
