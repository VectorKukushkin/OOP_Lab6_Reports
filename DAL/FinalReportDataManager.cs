using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    class FinalReportDataManager : IFinalReportDataManager
    {
        protected readonly Dictionary<Employee, FinalReport> FinalReports = new Dictionary<Employee, FinalReport>();

        public void Update(Employee employee)
        {
            if (!FinalReports.ContainsKey(employee))
                FinalReports.Add(employee, new FinalReport(employee));
        }

        public FinalReport Get(Employee employee)
        {
            if (employee != null)
                if (FinalReports.ContainsKey(employee))
                    return FinalReports[employee];
            return null;
        }
    }
}
