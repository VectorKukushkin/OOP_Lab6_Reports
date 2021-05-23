using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    interface IEmployeeManager
    {
        void AddEmployee(string employee);

        void AddEmployee(string employee, Employee director);

        Employee GetEmployee(string employee);

        Employee GetDirector(Employee employee);

        void SetDirector(Employee employee, Employee director);

        HashSet<Employee> GetSubordinates(Employee employee);

        HashSet<Employee> GetAllEmployees();
    }
}
