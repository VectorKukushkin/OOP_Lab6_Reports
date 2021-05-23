using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports
{
    class Employee
    {
        public Employee(string name, Employee director = null)
        {
            Name = name;
            Director = director;
        }

        public readonly string Name;
        public Employee Director { set; get; }
        public HashSet<Employee> Subordinates = new HashSet<Employee>();
    }
}
