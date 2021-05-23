using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.UI
{
    interface IPresentationManager
    {
        // employees

        void AddEmployee(string employee);

        void AddEmployee(string employee, string director);

        string GetDirector(string employee);

        void SetDirector(string employee, string director);

        string GetSubordinates(string employee);

        string GetHierarchy(string employee);

        // tasks

        string GetDescription(string task);

        string FindByCreationTime(DateTime date);

        string FindByLastChange(DateTime date);

        string FindByEmployee(string employee);

        string FindByEmployeeChanges(string employee);

        void CreateTask(string name, string description);

        void AddComment(string task, string employee, string text);

        void SetEmployee(string task, string employee);

        void SetStatus(string task, Status status);

        string GetSubordinatesTasks(string employee);

        // reports

        string GetReportText(uint sprint, string employee, DateTime date);

        string GetReportText(string employee, DateTime date);

        string GetReportText(string employee);

        void SetReportText(string employee, string text);

        string GetFinalReportText(uint sprint, string employee);

        string GetFinalReportText(string employee);

        void SetFinalReportText(string employee, string text);

        string GetFullReport(uint sprint, string employee, DateTime date);

        string GetFullReport(string employee, DateTime date);

        string GetFullFinalReport(uint sprint, string employee);

        string GetFullFinalReport(string employee);

        void FinishFinalReport(string employee);

        void FinishSprint();
    }
}
