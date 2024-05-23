using System;
using static System.Console;
namespace inheritance
{
    internal class Program
    {
        public class Human
        {
            protected string _firstName;
            protected string _lastName;
            protected DateTime _birthday;

            public Human() { }
            /*
            public Human(string firstName, string lastName)
            {
                _firstName = firstName;
                _lastName = lastName;
            }
            public Human(string firstName, string lastName, DateTime bithday) : this(firstName, lastName)
            {
                _birthday = bithday;
            }
            все, что выше, написано до билдера, это пример*/
            public virtual void Show()
            {
                WriteLine($"\nФамилия: {_lastName}\nИмя: {_firstName}\nДата рождения:{_birthday}");
            }

            //setters
            public void SetFirstName(string firstName) {
                _firstName = firstName;
            }
            public void SetLastName(string lastName) {
                _lastName = lastName;
            }
            public void SetBirthDate(DateTime data)
            {
                _birthday = data;
            }

        }
        public class Employee : Human
        {


            protected double _salary { get; set; }
            protected string _country { get; set; }
            public Employee() { }
            /*
            public Employee(string fName, string lName) : base(fName, lName) { }

            public Employee(string fName, string lName, double salary) : base(fName, lName) {
                _salary = salary;
            }
            public Employee(string fName, string lName, DateTime _bithday, double salary) : base(fName, lName)
            {
                _salary = salary;
            }
            все, что выше, написано до билдера, это пример*/
            public void SetSalary(double salary)
            {
                _salary = salary;
            }
            public void SetCountry(string country)
            {
                _country = country;
            }
            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Заработная плата: {_salary}");
                Console.WriteLine($"Страна: {_country}");
            }
        }
        public class EmployeeBuilder {
            Employee employee = new Employee();

            public EmployeeBuilder SetFirstName(string first) {
                employee.SetFirstName(first);
                return this;
            }
            public EmployeeBuilder SetLastName(string last)
            {
                employee.SetLastName(last);
                return this;
            }
            public EmployeeBuilder SetBirthDate(DateTime data)
            {
                employee.SetBirthDate(data);
                return this;
            }
            public EmployeeBuilder SetSalary(double salat)
            {
                employee.SetSalary(salat);
                return this;
            }
            public EmployeeBuilder SetCountry(string country)
            {
                employee.SetCountry(country);
                return this;
            }

            public Employee build() { return employee; }
        }
        /*
        public sealed class Tutor : Human {}
        public class TutSon : Tutor { }
        sealed - запечатанный, те от него не может быть наследования */

        public class Manager : Employee {
            public void ShowManager()
            {
                Console.WriteLine("I'm a manager");
            }
        }
        public class Scientist : Employee {
            public void ShowScientist()
            {
                Console.WriteLine("I'm a scientist");
            }
        }
        public class Specialist : Employee {
            public void ShowSpecialist()
            {
                Console.WriteLine("I'm a specialist");
            }
        }

        static void Main(string[] args)
        {

            Employee employee = new EmployeeBuilder().
                SetFirstName("Jack").
                SetLastName("Smith").
                SetBirthDate(DateTime.Now).
                SetSalary(1488).
                SetCountry("Russia").
                build();
            employee.Show();
            /*работает через точку, тк сделали return this в сеттерах(возвращаем обновленный employeeBuilder)*/

            Employee[] employes = new Employee[3] { new Manager(), new Scientist(), new Specialist() };
            foreach (Employee empl in employes)
            {
                empl.Show();

                try
                {
                    ((Scientist)empl).ShowScientist();
                }
                catch { }

                Specialist specialist = empl as Specialist;
                if(specialist != null)
                {
                    specialist.ShowSpecialist();
                }

                if(empl is Manager)
                {
                    (empl as Manager).ShowManager();
                }
            }
           
        }
    }
}
