using System;

namespace PatternTest.SimpleFactory
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

    internal sealed class QA: IWorker
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
        IWorker HireWorker(WorkerType workerType);
    }

    internal sealed class WorkerFactory : IWorkerFactory
    {
        public IWorker HireWorker(WorkerType workerType)
        {
            switch (workerType)
            {
                case WorkerType.HR:
                    return new HR();
                case WorkerType.Programmer:
                    return new Programmer();
                case WorkerType.QA:
                    return new QA();
                default:
                    return new HR();
            }
        }
    }
}
