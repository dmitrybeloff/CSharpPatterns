using PatternTest.Structural;
using PatternTest.Structural.Bridge;
using System;
using Flyweight = PatternTest.Structural.Flyweight;
using Strategy = PatternTest.Behavioral.Strategy;

namespace PatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton Test
            Console.WriteLine("Singleton Test");

            var singleton = Singleton.CreateSingletonObj(1);

            var singleton2 = Singleton.CreateSingletonObj(2); // не создается новый экземпляр

            // Simple Factory test
            Console.WriteLine(Environment.NewLine + "Simple Factory test");

            SimpleFactory.IWorkerFactory workerFactory = new SimpleFactory.WorkerFactory();
            var simpleFactoryHR = workerFactory.HireWorker(SimpleFactory.WorkerType.HR);
            simpleFactoryHR.GoToWork();

            // Factory test
            Console.WriteLine(Environment.NewLine + "Factory test");

            Factory.IWorkerFactory qAFactory = new Factory.QAFactory();
            Factory.IWorker factoryQA = qAFactory.HireWorker();
            factoryQA.GoToWork();

            // Abstract factory test
            Console.WriteLine(Environment.NewLine + "Abstract Factory test");

            AbstractFactory.ICompanyFactory companyOneFactory = new AbstractFactory.CompanyOneFactory();
            AbstractFactory.IWorker comopanyOneProgrammer = companyOneFactory.GetWorker();
            comopanyOneProgrammer.GoHome();
            AbstractFactory.IVisitor companyOneVisitor = companyOneFactory.GetVisitor();
            companyOneVisitor.Visit();

            // Builder test
            Console.WriteLine(Environment.NewLine + "Builder test");

            Director director = new Director();
            IPhoneBuilder androidBuilder = new AndroidPhoneBuilder();
            director.Construct(androidBuilder);
            Console.WriteLine(androidBuilder.Phone.ToString());

            // Decorator test
            Console.WriteLine(Environment.NewLine + "Decorator test");

            Employee programmer = new Programmer();
            programmer = new Junior(programmer);
            Console.WriteLine(programmer);

            Employee qA = new QA();
            qA = new Middle(qA);
            Console.WriteLine(qA);

            // Adapter test
            Console.WriteLine(Environment.NewLine + "Adapter test");

            Company company = new Company();

            CompanyOneEmployee companyOneEmployee = new CompanyOneEmployee();
            company.TransferEmployee(companyOneEmployee);

            CompanyTwoEmployee companyTwoEmployee = new CompanyTwoEmployee();
            ITransferable employeeAdapter = new EmployeeAdapter(companyTwoEmployee);
            company.TransferEmployee(employeeAdapter);

            // Composite test
            Console.WriteLine(Environment.NewLine + "Composite test");

            Component headOfDepartment = new Member(Position.HeadOfDepartment, "Vasiliy Michailovich");
            Component firstAssistant = new Member(Position.Assistant, "Yuri Gagarin");
            Component secondAssistant = new Member(Position.Assistant, "German Popov");
            Component firstWorker = new Member(Position.Worker, "Layka");
            Component secondWorker = new Member(Position.Worker, "Muha");

            headOfDepartment.Add(firstAssistant);
            headOfDepartment.Add(secondAssistant);

            firstAssistant.Add(firstWorker);
            secondAssistant.Add(secondWorker);

            headOfDepartment.Print();

            // Bridge test
            Console.WriteLine(Environment.NewLine + "Bridge test");

            MessageManager messageManager = new SimpleMessageManager(new WebService());
            messageManager.Send("Hellow World!");

            messageManager.Sender = new ThirdPartySender();
            messageManager.Send("Hello World!");

            // Flyweight test
            Console.WriteLine(Environment.NewLine + "Flyweight test");

            Flyweight.ProgrammerFactory programmerFactory = new Flyweight.ProgrammerFactory();

            for (var i = 0; i < 5; i++)
            {
                var fJuniorProgrammer = programmerFactory.GetProgrammer("Junior");
                fJuniorProgrammer.Pay(1.1f);
            }

            Console.WriteLine($"Number of objects in programmerFactory is {programmerFactory.Programmers.Count}");

            // Strategy test
            Console.WriteLine(Environment.NewLine + "Strategy test");

            Strategy.IEmployee strategyProgrammer = new Strategy.Programmer();
            Strategy.EmployeeActions employeeActions = new Strategy.EmployeeActions(strategyProgrammer);
            employeeActions.EmployeeGoHome();

            employeeActions.Employee = new Strategy.QA();
            employeeActions.EmployeeGoHome();
        }
    }
}
