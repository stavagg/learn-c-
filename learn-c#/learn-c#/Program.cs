/******************************************************************************
создать и добавить в класс "дебетовая карта" ифнормацию о сумме денег на карте. Выполните перегрузку операторов: 
+(увеличение суммы на указанную сумму),
-(для уменьшения суммы денег на указанное число),
==(для проверки равенства cvc кода),
< и >,
!=
использовать механизм свойств для полей класса.
*******************************************************************************/
using System.Security.Cryptography;

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
            public int cvv { get; set; }
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
            public static Debit operator +(Debit c1, Debit c2)
            {
                c1.money += c2.money;
                return c1;
            }
            public static Debit operator -(Debit c1, Debit c2)
            {
                c1.money -= c2.money;
                return c1;
            }
            public static bool operator ==(Debit c1, Debit c2)
            {
                return c1.number == c2.number && c1.cvv == c2.cvv;
            }
            public static bool operator !=(Debit c1, Debit c2)
            {
                return c1.number != c2.number && c1.cvv != c2.cvv;
            }
            public static bool operator >(Debit c1, Debit c2)
            {
                return (c1.money > c2.money);
            }
            public static bool operator <(Debit c1, Debit c2)
            {
                return (c1.money < c2.money);
            }

        }

        /*



        */
        static void Main(string[] args)
        {
            Debit d1 = new Debit { money = 111, number = 100, cvv = 123};
            d1.Print();
            Debit d2 = new Debit { money = 222, number = 100, cvv = 123};
            Debit d3 = new Debit { money = 22288, number = 100, cvv = 123 };
            d1 +=  45;
            d1.Print();
            d1 += d2;
            d1.Print();
            if (d1 == d2){
                Console.WriteLine("ravno");

            }
            else{
                Console.WriteLine("neravno");
            }
            if (d1 > d3) {
                Console.WriteLine(">");
            }
            else
            {
                Console.WriteLine("<");
            }
        }
    }
}
