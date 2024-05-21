/******************************************************************************
создать и добавить в класс "дебетовая карта" ифнормацию о сумме денег на карте. Выполните перегрузку операторов: 
+(увеличение суммы на указанную сумму),
-(для уменьшения суммы денег на указанное число),
==(для проверки равенства cvc кода),
< и >,
!=
использовать механизм свойств для полей класса.
*******************************************************************************/
namespace learn_c_
{
    internal class Program
    {
        class Debit
        {

            public void Print()
            {
                Console.WriteLine($"Amount is: {money}");
            }
            public double money { get; set; }
            public double number {  get; set; }
        public static Debit operator +(Debit c1, double number)
        {
            c1.money += number;
            return c1;
        }
        public static Debit operator -(Debit c1, double number)
        {
            c1.money -= number;
            return c1;
        }
        }

        /*

        public static bool operator ==(Debit c1, Debit c2)
        {
            return c1.cvv == c2.cvv;
        }
        public static bool operator !=(Debit c1, Debit c2)
        {
            return c1.cvv != c2.cvv;
        }
        */
        static void Main(string[] args)
        {
            Debit d1 = new Debit { money = 111, number = 100 };
            d1.Print();
            Debit d2 = new Debit { money = 222, number = 50 };
            d1 = d1 +  45;
            d1.Print();
        }
    }
}
