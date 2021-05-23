using OOP_Lab6_Reports.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.BLL
{
    class EmployeeManager : IEmployeeManager
    {
        protected IEmployeeDataManager EmployeeData = new EmployeeDataManager();

        public void AddEmployee(string employee)
        {
            EmployeeData.Add(new Employee(employee));
        }

        public void AddEmployee(string employee, Employee director)
        {
            if (director != null)
            {
                EmployeeData.Add(new Employee(employee, director));
                director.Subordinates.Add(EmployeeData.Get(employee));
            }
        }

        public Employee GetEmployee(string employee)
        {
            return EmployeeData.Get(employee);
        }

        public Employee GetDirector(Employee employee)
        {
            if (employee != null)
            {
                if (employee.Director != null)
                {
                    return employee.Director;
                }
                else
                {
                    throw new Exception("There is no director of the employee!");
                }
            }
            return new Employee("");
        }

        private bool CanBeDirector(Employee employee, Employee director)
        {
            Employee e = director;
            while (e != null)
            {
                if (e == employee)
                {
                    return false;
                }
                e = e.Director;
            }
            return true;
        }

        public void SetDirector(Employee employee, Employee director)
        {
            if (employee != null && director != null)
            {
                if (CanBeDirector(employee, director))
                {
                    if (employee.Director != director)
                    {
                        if (employee.Director != null)
                        {
                            employee.Director.Subordinates.Remove(employee);
                        }
                        employee.Director = director;
                        director.Subordinates.Add(employee);
                    }
                    else
                    {
                        throw new Exception("The second employee is already the director of the first employee!");
                    }
                }
                else
                {
                    throw new Exception("The second employee can't be the director of the first employee!");
                }
            }
        }

        public HashSet<Employee> GetSubordinates(Employee employee)
        {
            if (employee != null)
            {
                return employee.Subordinates;
            }
            return new HashSet<Employee>();
        }

        public HashSet<Employee> GetAllEmployees()
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach (Employee employee in EmployeeData.GetAll())
            {
                employees.Add(employee);
            }
            return employees;
        }
    }
}
