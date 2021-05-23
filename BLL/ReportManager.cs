using OOP_Lab6_Reports.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    class ReportManager : IReportManager
    {
        protected IReportDataManager ReportDataManager = new ReportDataManager();
        protected IFinalReportDataManager FinalReportDataManager = new FinalReportDataManager();

        public string GetReportText(Employee employee, DateTime date)
        {
            return ReportDataManager.Get(employee, date).Text;
        }

        public string GetFinalReportText(Employee employee)
        {
            return FinalReportDataManager.Get(employee).Text;
        }

        public void SetReportText(Employee employee, string text)
        {
            if (employee != null)
            {
                ReportDataManager.Update(employee);
                ReportDataManager.Get(employee).Text = text;
            }
        }

        public void SetFinalReportText(Employee employee, string text)
        {
            if (employee != null)
            {
                FinalReportDataManager.Update(employee);
                FinalReportDataManager.Get(employee).Text = text;
            }
        }

        public Report GetReport(Employee employee, DateTime date)
        {
            return ReportDataManager.Get(employee, date);
        }

        public FinalReport GetFinalReport(Employee employee)
        {
            return FinalReportDataManager.Get(employee);
        }

        public void AddTask(Employee employee, Task task)
        {
            if (employee != null)
            {
                ReportDataManager.Update(employee);
                ReportDataManager.Get(employee).Tasks.Add(task);
                FinalReportDataManager.Update(employee);
                if (!FinalReportDataManager.Get(employee).Ready)
                {
                    FinalReportDataManager.Get(employee).Tasks.Add(task);
                }
                else
                {
                    throw new Exception("The report is already ready!");
                }
            }
        }

        public void AddReports(Employee director, HashSet<Employee> subordinates)
        {
            FinalReportDataManager.Update(director);
            if (!FinalReportDataManager.Get(director).Ready)
            {
                HashSet<Report> reports = new HashSet<Report>();
                foreach (Employee employee in subordinates)
                {
                    foreach (Report report in ReportDataManager.GetAll(employee))
                    {
                        reports.Add(report);
                    }
                }
                FinalReportDataManager.Get(director).Reports = reports;
            }
            else
            {
                throw new Exception("The report is already ready!");
            }
        }

        public void FinishFinalReport(Employee employee)
        {
            FinalReportDataManager.Update(employee);
            FinalReportDataManager.Get(employee).Ready = true;
        }
    }
}
