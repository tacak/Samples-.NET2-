using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolesSample
{
    public interface IGreeting
    {
        string Greet(string name);
    }

    public abstract class Greeting : IGreeting
    {
        protected Greeting()
        {
        }

        public abstract string Greet(string name);
    }

    public class Morning : Greeting
    {
        public override string Greet(string name)
        {
            return string.Format("Good morning, {0}.", name);
        }
    }

    public static class GreetingFactory
    {
        public static IGreeting CreateMorning()
        {
            return new Morning();
        }
    }
}
