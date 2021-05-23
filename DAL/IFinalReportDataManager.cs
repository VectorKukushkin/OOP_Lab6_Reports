using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    interface IFinalReportDataManager
    {
        void Update(Employee employee);
        FinalReport Get(Employee employee);
    }
}
