using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports
{
    class FinalReport : BaseReport
    {
        public FinalReport(Employee employee)
        {
            Employee = employee;
            ready = false;
        }

        private bool ready;

        public bool Ready
        {
            set
            {
                if (!ready)
                {
                    if (ready != value)
                    {
                        ready = true;
                    }
                    else
                    {
                        throw new Exception("The report isn't ready anyway!");
                    }
                }
                else
                {
                    throw new Exception("The report is already ready!");
                }
            }
            get
            {
                return ready;
            }
        }

        public override string Text
        {
            set
            {
                if (!Ready)
                {
                    text = value;
                }
                else
                {
                    throw new Exception("The report is already ready!");
                }
            }
            get
            {
                return text;
            }
        }

        public HashSet<Report> Reports { set; get; }
    }
}
