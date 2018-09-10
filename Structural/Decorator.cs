namespace PatternTest.Structural
{
    internal enum EmployeeType
    {
        Programmer,
        QA
    }

    internal enum EmployeeRank
    {
        Junior,
        Middle,
        Senior
    }

    internal abstract class Employee
    {
        public EmployeeType Type { get; }

        public Employee(EmployeeType type)
        {
            Type = type;
        }

        public abstract int Salary();
    }

    internal sealed class Programmer: Employee
    {
        public Programmer() : base(EmployeeType.Programmer) { }

        public override int Salary()
        {
            return 1000;
        }
    }

    internal sealed class QA : Employee
    {
        public QA() : base(EmployeeType.QA) { }

        public override int Salary()
        {
            return 900;
        }
    }

    internal abstract class EmployeeDecorator : Employee
    {
        protected Employee employee;
        protected EmployeeRank rank;

        public EmployeeDecorator(EmployeeRank rank, Employee employee) : base(employee.Type)
        {
            this.employee = employee;
            this.rank = rank;
        }

        public override string ToString()
        {
            return $"{rank.ToString()} {employee.Type.ToString()} earns {this.Salary().ToString()}";
        }
    }

    internal sealed class Junior : EmployeeDecorator
    {
        public Junior(Employee employee) : base(EmployeeRank.Junior, employee)
        { }

        public override int Salary()
        {
            return employee.Salary();
        }        
    }

    internal sealed class Middle : EmployeeDecorator
    {
        public Middle(Employee employee) : base(EmployeeRank.Middle, employee)
        { }

        public override int Salary()
        {
            return employee.Salary() + 500;
        }
    }

    internal sealed class Senior : EmployeeDecorator
    {
        public Senior(Employee employee) : base(EmployeeRank.Senior, employee)
        { }

        public override int Salary()
        {
            return employee.Salary() + 1000;
        }
    }
}
