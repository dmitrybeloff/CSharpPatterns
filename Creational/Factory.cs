using System;

namespace PatternTest.Factory
{
    internal enum WorkerType
    {
        QA,
        Programmer,
        HR
    }

    internal interface IWorker
    {
        void GoToWork();
        void GoHome();
    }

    internal sealed class QA : IWorker
    {
        public void GoToWork()
        {
            Console.WriteLine("QA goes to work");
        }

        public void GoHome()
        {
            Console.WriteLine("QA goes homes");
        }
    }

    internal sealed class Programmer : IWorker
    {
        public void GoToWork()
        {
            Console.WriteLine("Programmer goes to work");
        }

        public void GoHome()
        {
            Console.WriteLine("Programmer goes homes");
        }
    }

    internal sealed class HR : IWorker
    {
        public void GoToWork()
        {
            Console.WriteLine("HR goes to work");
        }

        public void GoHome()
        {
            Console.WriteLine("HR goes homes");
        }
    }

    internal interface IWorkerFactory
    {
        IWorker HireWorker();
    }

    internal sealed class QAFactory : IWorkerFactory
    {
        public IWorker HireWorker()
        {
            return new QA();
        }
    }

    internal sealed class ProgrammerFactory : IWorkerFactory
    {
        public IWorker HireWorker()
        {
            return new Programmer();
        }
    }

    internal sealed class HRFactory : IWorkerFactory
    {
        public IWorker HireWorker()
        {
            return new HR();
        }
    }
}
