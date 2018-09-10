using System;
using System.Collections.Generic;

namespace PatternTest.Structural.Flyweight
{
    internal abstract class Programmer
    {
        protected int salary;

        public abstract void Pay(float k); 
    }

    internal sealed class Junior : Programmer
    {
        public Junior()
        {
            this.salary = 500;
        }

        public override void Pay(float k)
        {
            Console.WriteLine($"Junior has been paid {salary*k}");
        }
    }

    internal sealed class Middle : Programmer
    {
        public Middle()
        {
            this.salary = 1000;
        }

        public override void Pay(float k)
        {
            Console.WriteLine($"Middle has been paid {salary * k}");
        }
    }

    internal sealed class ProgrammerFactory
    {
        public Dictionary<string, Programmer> Programmers { get; set; }
        public ProgrammerFactory()
        {
            Programmers = new Dictionary<string, Programmer>();
        }

        public Programmer GetProgrammer(string key)
        {
            if (Programmers.ContainsKey(key))
                return Programmers[key];
            else
            {
                Programmer programmer;
                switch(key)
                {
                    case "Junior":
                        programmer = new Junior();
                        Programmers.Add(key, programmer);
                        return programmer;
                    case "Middle":
                        programmer = new Middle();
                        Programmers.Add(key, programmer);
                        return programmer;
                    default:
                        return null;
                }
                
            }
        }
    }
}
