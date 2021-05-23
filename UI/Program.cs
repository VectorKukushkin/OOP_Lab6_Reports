using OOP_Lab6_Reports.UI;
using System;

namespace OOP_Lab6_Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            IPresentationManager manager = new PresentationManager();

            manager.AddEmployee("Alex");
            manager.AddEmployee("Richard", "Alex");
            manager.AddEmployee("Tim", "Alex");
            manager.AddEmployee("Bruce", "Alex");
            manager.AddEmployee("Carl", "Richard");
            manager.AddEmployee("Hans", "Richard");
            manager.AddEmployee("John", "Tim");

            Console.WriteLine(manager.GetHierarchy("Alex"));

            manager.CreateTask("Task1", "This is the first task.");
            manager.CreateTask("Task2", "This is the second task.");
            manager.CreateTask("Task3", "It's a task.");
            manager.CreateTask("Task4", "It's a task.");
            manager.CreateTask("Task5", "It's a task.");

            manager.SetEmployee("Task1", "Alex");
            manager.SetEmployee("Task1", "Richard");
            manager.SetEmployee("Task2", "Alex");
            manager.SetEmployee("Task3", "Alex");
            manager.SetEmployee("Task4", "Carl");
            manager.SetEmployee("Task5", "Hans");

            manager.SetStatus("Task1", Status.Resolved);
            manager.SetStatus("Task2", Status.Resolved);
            manager.SetStatus("Task3", Status.Resolved);
            manager.SetStatus("Task4", Status.Resolved);
            manager.SetStatus("Task5", Status.Resolved);

            manager.SetReportText("Alex", "This report is made by Alex");
            manager.SetReportText("Richard", "This report is made by Richard");

            Console.WriteLine(manager.GetFullReport("Alex", DateTime.Now));
            Console.WriteLine(manager.GetFullReport("Richard", DateTime.Now));

            manager.SetFinalReportText("Alex", "This final report is made by Alex");
            manager.SetFinalReportText("Richard", "This final report is made by Richard");

            manager.FinishFinalReport("Alex");
            manager.FinishFinalReport("Richard");

            Console.WriteLine(manager.GetFullFinalReport("Alex"));
            Console.WriteLine(manager.GetFullFinalReport("Richard"));
        }
    }
}
