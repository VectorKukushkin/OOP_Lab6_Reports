using OOP_Lab6_Reports.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.UI
{
    class PresentationManager : IPresentationManager
    {
        protected readonly IManager Manager = new Manager();

        // employees

        public void AddEmployee(string employee)
        {
            Manager.AddEmployee(employee);
        }

        public void AddEmployee(string employee, string director)
        {
            Manager.AddEmployee(employee, director);
        }

        public string GetDirector(string employee)
        {
            return Manager.GetDirector(employee);
        }

        public void SetDirector(string employee, string director)
        {
            Manager.SetDirector(employee, director);
        }

        public string GetSubordinates(string employee)
        {
            HashSet<Employee> employees = Manager.GetSubordinates(employee);
            string subordinates = "";
            foreach (Employee e in employees)
            {
                subordinates += e.Name + "\n";
            }
            return subordinates;
        }

        private string GetHierarchy(int range, Employee employee)
        {
            string hierarchy = "";
            for (int i = 0; i < range; i++)
            {
                hierarchy += "  ";
            }
            hierarchy += employee.Name + "\n";
            foreach (Employee e in employee.Subordinates)
            {
                hierarchy += GetHierarchy(range + 1, e);
            }
            return hierarchy;
        }

        public string GetHierarchy(string employee)
        {
            return GetHierarchy(0, Manager.GetEmployee(employee));
        }

        // tasks

        public string GetDescription(string task)
        {
            return Manager.GetDescription(task);
        }

        private string WriteTasks(HashSet<Task> tasks)
        {
            string list = "";
            foreach (Task task in tasks)
            {
                list += task.Name + "\n";
            }
            return list;
        }

        public string FindByCreationTime(DateTime date)
        {
            return WriteTasks(Manager.FindByCreationTime(date));
        }

        public string FindByLastChange(DateTime date)
        {
            return WriteTasks(Manager.FindByLastChange(date));
        }

        public string FindByEmployee(string employee)
        {
            return WriteTasks(Manager.FindByEmployee(employee));
        }

        public string FindByEmployeeChanges(string employee)
        {
            return WriteTasks(Manager.FindByEmployeeChanges(employee));
        }

        public void CreateTask(string name, string description)
        {
            Manager.CreateTask(name, description);
        }

        public void AddComment(string task, string employee, string text)
        {
            Manager.AddComment(task, employee, text);
        }

        public void SetEmployee(string task, string employee)
        {
            Manager.SetEmployee(task, employee);
        }

        public void SetStatus(string task, Status status)
        {
            Manager.SetStatus(task, status);
        }

        public string GetSubordinatesTasks(string employee)
        {
            return WriteTasks(Manager.GetSubordinatesTasks(employee));
        }

        // reports

        public string GetReportText(uint sprint, string employee, DateTime date)
        {
            return Manager.GetReportText(sprint, employee, date);
        }

        public string GetReportText(string employee, DateTime date)
        {
            return Manager.GetReportText(employee, date);
        }

        public string GetReportText(string employee)
        {
            return Manager.GetReportText(employee);
        }

        public void SetReportText(string employee, string text)
        {
            Manager.SetReportText(employee, text);
        }

        public string GetFinalReportText(uint sprint, string employee)
        {
            return Manager.GetFinalReportText(sprint, employee);
        }

        public string GetFinalReportText(string employee)
        {
            return Manager.GetFinalReportText(employee);
        }

        public void SetFinalReportText(string employee, string text)
        {
            Manager.SetFinalReportText(employee, text);
        }

        private string GetFullReport(Report report)
        {
            if (report != null)
            {
                string text = report.Employee.Name + " " + report.Date.Date + "\n";
                for (int i = 0; i < 20; i++)
                {
                    text += "-";
                }
                text += "\n" + report.Text + "\n";
                for (int i = 0; i < 20; i++)
                {
                    text += "-";
                }
                text += "\n";
                foreach (Task task in report.Tasks)
                {
                    text += task.Name + "\n";
                }
                return text;
            }
            return "";
        }

        public string GetFullReport(uint sprint, string employee, DateTime date)
        {
            return GetFullReport(Manager.GetReport(sprint, employee, date));
        }

        public string GetFullReport(string employee, DateTime date)
        {
            return GetFullReport(Manager.GetReport(employee, date));
        }

        private string GetFullFinalReport(FinalReport report)
        {
            if (report != null)
            {
                string text = report.Employee.Name + "\n";
                for (int i = 0; i < 20; i++)
                {
                    text += "-";
                }
                text += "\n" + report.Text + "\n";
                for (int i = 0; i < 20; i++)
                {
                    text += "-";
                }
                text += "\n";
                foreach (Task task in report.Tasks)
                {
                    text += task.Name + "\n";
                }
                for (int i = 0; i < 20; i++)
                {
                    text += "-";
                }
                text += "\n";
                foreach (Report r in report.Reports)
                {
                    text += r.Employee.Name + " " + r.Date + "\n";
                }
                return text;
            }
            return "";
        }

        public string GetFullFinalReport(uint sprint, string employee)
        {
            return GetFullFinalReport(Manager.GetFinalReport(sprint, employee));
        }

        public string GetFullFinalReport(string employee)
        {
            return GetFullFinalReport(Manager.GetFinalReport(employee));
        }

        public void FinishFinalReport(string employee)
        {
            Manager.FinishFinalReport(employee);
        }

        public void FinishSprint()
        {
            Manager.FinishSprint();
        }
    }
}
