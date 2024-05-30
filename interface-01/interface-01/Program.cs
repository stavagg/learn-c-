namespace interface_01
{
    internal class Program
    {

        abstract class Human
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public override string ToString()
            {
                return $"\nФамилия: {LastName}, Имя:{FirstName}, Дата Рождения: {BirthDate.ToLongDateString()}";
            }
        }
        abstract class Employee : Human
        {
            public string Position {  get; set; }
            public double Salary { get; set; }
            public override string ToString()
            {
                return base.ToString() + $"\nДолжность: {Position}, ЗП: {Salary} $";
            }
        }
        class Director : Employee, IManager
        {
            public List<IWorker> ListOfWorker { get; set; }
            public void MakeBudget()
            {
                Console.WriteLine("Формирую бюджет и пилю бабки\n");
            }
            public void Control()
            {
                Console.WriteLine("Еду в Турцию\n");
            }
            public void Organaize()
            {
                Console.WriteLine("Ору на всех по фану\n");
            }
        }
        class Seller : Employee, IWorker
        {
            bool isWorkig = true;

            public bool IsWorking
            {
                get { return isWorkig; }
            }
            public string Work()
            {
                return "Продаю всякое";
            }
        }
        class Cashier : Employee, IWorker
        {
            bool isWorking = true;
            public bool IsWorking
            {
                get
                {
                    return isWorking;
                }
            }

            public string Work()
            {
                return "Принимаю оплату";
            }
        }
        class Stonekeeper : Employee, IWorker
        {
            bool isWorking = true;
            public bool IsWorking
            {
                get
                {
                    return isWorking;
                }
            }

            public string Work()
            {
                return "Коробка тяжелая бля";
            }
        }
        public interface IWorker
        {
            //event EventHandler WorkEnd;
            bool IsWorking { get; }
            string Work();
        }
        public interface IManager
        {
            List<IWorker> ListOfWorker { get; set; }
            void Organaize();
            void MakeBudget();
            void Control();
        }
        static void Main(string[] args)
        {
            Director director = new Director()
            {
                LastName = "Doe",
                FirstName = "John",
                BirthDate = new DateTime(1998, 10, 12),
                Position = "Директор",
                Salary = 12000
            };
            IWorker seller = new Seller()
            {
                LastName = "Beam",
                FirstName = "Jim",
                BirthDate = new DateTime(1488, 9, 11),
                Position = "Продавец",
                Salary = 1488
            };
            if (seller is Employee)
                Console.WriteLine($"Зп складовщика: {(seller as Employee).Salary}");
            director.ListOfWorker = new List<IWorker> {
                seller, new Cashier { LastName = "Smith", FirstName = "Nicole", BirthDate = new DateTime(1956, 5, 23),
                Position = "Кассир", Salary = 3780},
                new Stonekeeper{ LastName = "Ross", FirstName = "Bob", BirthDate =new DateTime(1999, 2, 2), Position = "Кладмен", Salary = 228}
            };
            Console.WriteLine(director);
            if (director is IManager)
            {
                director.Control();
            }
            foreach (IWorker item in director.ListOfWorker)
            {
                Console.WriteLine(item);
                if (item.IsWorking)
                {
                    Console.WriteLine(item.Work());
                }
            }
        }
    }
}
