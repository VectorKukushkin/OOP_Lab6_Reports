using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    interface IReportDataManager
    {
        void Update(Employee employee);
        Report Get(Employee employee, DateTime date);
        Report Get(Employee employee);
        HashSet<Report> GetAll(Employee employee);
    }
}
