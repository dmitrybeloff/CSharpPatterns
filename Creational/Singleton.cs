using System;

namespace PatternTest
{
    internal sealed class Singleton
    {
        private static Lazy<Singleton> lazy = null;

        public int Count { get; set; }

        private Singleton(int parameter)
        {
            Count = parameter;
        }

        public static Singleton CreateSingletonObj(int parameter)
        {
            if (lazy == null)
            {
                lazy = new Lazy<Singleton>(() => new Singleton(parameter));
            }
            return lazy.Value;
        }

    }
}
