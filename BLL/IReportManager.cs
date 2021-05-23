using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    interface IReportManager
    {
        string GetReportText(Employee employee, DateTime date);

        string GetFinalReportText(Employee employee);

        void SetReportText(Employee employee, string text);

        void SetFinalReportText(Employee employee, string text);

        Report GetReport(Employee employee, DateTime date);

        FinalReport GetFinalReport(Employee employee);

        void AddTask(Employee employee, Task task);

        void AddReports(Employee director, HashSet<Employee> subordinates);

        void FinishFinalReport(Employee employee);
    }
}
