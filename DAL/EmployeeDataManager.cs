using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    class EmployeeDataManager : IEmployeeDataManager
    {
        protected readonly Dictionary<string, Employee> Employees = new Dictionary<string, Employee>();

        public HashSet<Employee> GetAll()
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach (Employee employee in Employees.Values)
            {
                employees.Add(employee);
            }
            return employees;
        }

        public Employee Get(string name)
        {
            if (!Employees.ContainsKey(name))
                throw new Exception("There is no the employee in the list!");
            return Employees[name];
        }

        public void Add(Employee employee)
        {
            if (Employees.ContainsKey(employee.Name))
                throw new Exception("The employee is already contained in the list!");
            Employees.Add(employee.Name, employee);
        }
    }
}
