using System;

namespace PatternTest.Structural
{
    internal interface ITransferable
    {
        void Transfer();
    }

    internal sealed class CompanyOneEmployee : ITransferable
    {
        public void Transfer()
        {
            Console.WriteLine("CompanyOneEmployee is transfered to another department");
        }
    }

    internal sealed class Company
    {
        public void TransferEmployee(ITransferable employee)
        {
            employee.Transfer();
        }
    }

    internal interface IMovable
    {
        void Move();
    }

    internal sealed class CompanyTwoEmployee : IMovable
    {
        public void Move()
        {
            Console.WriteLine("CompanyTwoEmployee is moved to another department");
        }
    }

    internal sealed class EmployeeAdapter : ITransferable
    {
        CompanyTwoEmployee employee;
        public EmployeeAdapter(CompanyTwoEmployee employee)
        {
            this.employee = employee;
        }

        public void Transfer()
        {
            this.employee.Move();
        }
    }
}
