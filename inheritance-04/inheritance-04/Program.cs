namespace inheritance_04
{
    internal class Program
    {
        class Tort
        {
            public bool _chocolate;
            public bool _cream;
            int _layers;
            int _candles;
            string _wishes;
            public Tort(bool chocolate, bool cream, int layers, int candles, string wishes)
            {
                _chocolate = chocolate;
                _cream = cream;
                _layers = layers;
                _candles = candles;
                _wishes = wishes;
            }
            public void print(Tort tort)
            {
                Console.WriteLine($"Наличие шоколада: {_chocolate}\n Наличие крема: {_cream}\nКоличество слоев: {_layers}\nКоличество свечей: {_candles}\n " +
                    $"Пожелания клиента: {_wishes}");
            }
        }
        static void Main(string[] args)
        {
            var tort = new Tort( true, false, 1, 3, "делайте хорошо плохо не делайте" );
            tort.print(tort);
        }
    }
}
