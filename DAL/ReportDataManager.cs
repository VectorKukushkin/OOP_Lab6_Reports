using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    class ReportDataManager : IReportDataManager
    {
        protected readonly Dictionary<Employee, Dictionary<DateTime, Report>> Reports = new Dictionary<Employee, Dictionary<DateTime, Report>>();

        public void Update(Employee employee)
        {
            if (!Reports.ContainsKey(employee))
                Reports.Add(employee, new Dictionary<DateTime, Report>());
            if (!Reports[employee].ContainsKey(DateTime.Now.Date))
                Reports[employee].Add(DateTime.Now.Date, new Report(employee, DateTime.Now.Date));
        }

        public Report Get(Employee employee, DateTime date)
        {
            if (employee != null)
                if (Reports.ContainsKey(employee))
                    if (Reports[employee].ContainsKey(date.Date))
                        return Reports[employee][date.Date];
            return null;
        }

        public Report Get(Employee employee)
        {
            return Get(employee, DateTime.Now);
        }

        public HashSet<Report> GetAll(Employee employee)
        {
            if (employee != null)
                if (Reports.ContainsKey(employee))
                {
                    HashSet<Report> reports = new HashSet<Report>();
                    foreach (Report report in Reports[employee].Values)
                    {
                        reports.Add(report);
                    }
                    return reports;
                }
            return new HashSet<Report>();
        }
    }
}
