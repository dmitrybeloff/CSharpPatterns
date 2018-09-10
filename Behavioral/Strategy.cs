using System;

namespace PatternTest.Behavioral.Strategy
{
    internal interface IEmployee
    {
        void GoHome();
    }

    internal sealed class Programmer : IEmployee
    {
        public void GoHome()
        {
            Console.WriteLine("Programmer goes home");
        }
    }

    internal sealed class QA : IEmployee
    {
        public void GoHome()
        {
            Console.WriteLine("QA goes home");
        }
    }

    internal sealed class EmployeeActions
    {
        public IEmployee Employee { get; set; }

        public EmployeeActions(IEmployee employee)
        {
            Employee = employee;
        }

        public void EmployeeGoHome()
        {
            Employee.GoHome();
        }
    }
}
