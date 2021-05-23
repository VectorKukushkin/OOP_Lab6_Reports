using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports.DAL
{
    interface IEmployeeDataManager : IEntityDataManager<Employee> { }

    interface ITaskDataManager : IEntityDataManager<Task> { }

    interface IEntityDataManager<T>
    {
        HashSet<T> GetAll();
        T Get(string name);

        void Add(T item);
    }
}
