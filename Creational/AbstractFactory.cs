using System;

namespace PatternTest.AbstractFactory
{
    internal interface IWorker
    {
        void GoToWork();
        void GoHome();
    }

    internal interface IVisitor
    {
        void Visit();
    }

    internal sealed class CompanyOneProgrammer : IWorker
    {
        public void GoToWork()
        {
            Console.WriteLine("Programmer, that works at 'Company One', goes to work");
        }

        public void GoHome()
        {
            Console.WriteLine("Programmer, that works at 'Company One', goes home");
        }
    }

    internal sealed class CompanyOneVisitor : IVisitor
    {
        public void Visit()
        {
            Console.WriteLine("Visitor visits 'Company One'");
        }
    }

    internal interface ICompanyFactory
    {
        IWorker GetWorker();
        IVisitor GetVisitor();
    }

    internal sealed class CompanyOneFactory : ICompanyFactory
    {
        public IWorker GetWorker()
        {
            return new CompanyOneProgrammer();
        }

        public IVisitor GetVisitor()
        {
            return new CompanyOneVisitor();
        }
    }
}
