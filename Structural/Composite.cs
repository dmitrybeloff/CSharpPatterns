using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternTest.Structural
{
    internal enum Position
    {
        HeadOfDepartment,
        Assistant,
        Worker
    }

    internal abstract class Component
    {
        protected Position type;
        protected string name;

        public Component(Position type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Print();
    }

    internal sealed class Member : Component
    {
        private List<Component> components;

        public Member(Position type, string name) : base(type, name)
        {
            components = new List<Component>();
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            switch(type)
            {
                case Position.Assistant:
                    Console.Write(" - ");
                    break;
                case Position.Worker:
                    Console.Write(" - - ");
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Member {name} has {components.Count()} subordients: ");
            components.ForEach(c => c.Print());
        }
    }
}
