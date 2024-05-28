using System;

namespace inheritance_03
{
    class Program
    {
        public abstract class Animal
        {
            readonly string _name;
            readonly string _characteristic;

            protected Animal(string name, string characteristic)
            {
                _name = name;
                _characteristic = characteristic;
            }

            public abstract void Voice();

            public override string ToString()
            {
                return $"Animal {_name} - {_characteristic}";
            }
        }

        class Tiger : Animal
        {
            public Tiger(string name, string characteristic) : base(name, characteristic) { }

            public override void Voice() 
            {
                Console.WriteLine("rrrrrrrrr");
            }
        }

        class Crocodile : Animal
        {
            public Crocodile(string name, string characteristic) : base(name, characteristic) { }
            public override void Voice()
            {
                Console.WriteLine("klac-klac");
            }
        }

        static void Main(string[] args)
        {
            var tiger = new Tiger("Sasha", "Big cat");
            var croco = new Crocodile("Fedya", "Zeleniy chel");

            tiger.Voice();
            Console.WriteLine(tiger.ToString());

            croco.Voice();
            Console.WriteLine(croco.ToString());
        }
    }
}
