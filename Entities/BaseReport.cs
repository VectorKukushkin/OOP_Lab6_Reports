using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab6_Reports
{
    abstract class BaseReport
    {
        public Employee Employee { get; protected set; }

        protected string text;

        public abstract string Text { get; set; }

        public readonly HashSet<Task> Tasks = new HashSet<Task>();
    }
}
