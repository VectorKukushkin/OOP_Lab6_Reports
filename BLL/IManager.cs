using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    interface IManager
    {
        uint SprintNumber { get; }

        // employees

        Employee GetEmployee(string employee);

        void AddEmployee(string employee);

        void AddEmployee(string employee, string director);

        string GetDirector(string employee);

        void SetDirector(string employee, string director);

        HashSet<Employee> GetSubordinates(string employee);

        // tasks

        string GetDescription(string task);

        HashSet<Task> FindByCreationTime(DateTime date);

        HashSet<Task> FindByLastChange(DateTime date);

        HashSet<Task> FindByEmployee(string employee);

        HashSet<Task> FindByEmployeeChanges(string employee);

        void CreateTask(string name, string description);

        void AddComment(string task, string employee, string text);

        void SetEmployee(string task, string employee);

        void SetStatus(string task, Status status);

        HashSet<Task> GetSubordinatesTasks(string employee);

        // reports

        string GetReportText(uint sprint, string employee, DateTime date);

        string GetReportText(string employee, DateTime date);

        string GetReportText(string employee);

        void SetReportText(string employee, string text);

        string GetFinalReportText(uint sprint, string employee);

        string GetFinalReportText(string employee);

        void SetFinalReportText(string employee, string text);

        Report GetReport(uint sprint, string employee, DateTime date);

        Report GetReport(string employee, DateTime date);

        FinalReport GetFinalReport(uint sprint, string employee);

        FinalReport GetFinalReport(string employee);

        void FinishFinalReport(string employee);

        void FinishSprint();
    }
}
