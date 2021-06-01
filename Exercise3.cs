using System;

namespace Sitech_ProgrammingExercise
{



    public partial class MainWindow
    {

        public interface IWord
        {
            void Print();
        }

        public interface IWord2 : IWord
        {
            new void Print();
        }

        public abstract class Base
        {
            protected static string msg = "send ";

            public Base()
            {
                Console.Write(this.GetString());
            }

            static Base()
            {
                Console.Write("Never ");
            }

            public virtual void Print()
            {
                Console.Write("to ");
            }

            protected virtual string GetString()
            {
                return "llama ";
            }
        }

        public class Derived : Base, IWord
        {

            static Derived()
            {
                Console.Write(Derived.msg);
            }

            public new virtual void Print()
            {
                Console.Write("do ");
            }

            protected override string GetString()
            {
                return "a ";
            }
        }

        public sealed class MoreDerived : Derived, IWord
        {
            public override void Print()
            {
                Console.Write("mach");
            }

            void IWord.Print()
            {
                Console.Write("a ");
            }

            protected override string GetString()
            {
                return "do ";
            }
        }

        public sealed class MoreDerived2 : Derived, IWord2
        {

            static MoreDerived2()
            {
                Console.Write("ine");
            }

            public new void Print()
            {
                Console.Write("job. ");
            }

            void IWord2.Print()
            {
                Console.Write("job.");
            }

            protected override string GetString()
            {
                return "'s ";
            }
        }

        public abstract class Unfinished : Base
        {
            protected new void Print()
            {
                Console.Write("camel ");
            }

            protected override string GetString()
            {
                return "human ";
            }
        }

        public class Finished : Unfinished
        {
        }


        // instantiate objects and call methods from any of the above classes to write 
        // "Never send a human to do a machine's job." 
        // to the console
        public void Exercise3()
        {
            
        }
    }
}

