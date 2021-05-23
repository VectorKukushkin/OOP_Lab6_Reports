using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OOP_Lab6_Reports
{
    class Report : BaseReport
    {
        public Report(Employee employee, DateTime date)
        {
            Employee = employee;
            Date = date;
        }

        public readonly DateTime Date;

        public override string Text
        {
            set
            {
                if (Date.Date == DateTime.Now.Date)
                {
                    text = value;
                }
                else
                {
                    throw new Exception("The report can't be changed!");
                }
            }
            get
            {
                return text;
            }
        }
    }
}
