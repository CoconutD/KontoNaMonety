using System.Globalization;

namespace KontoNaMonety
{
    internal class Automat
    {
        private readonly decimal[] _przyjmowaneMonety = { 5, 2, 1, 0.5m, 0.2m, 0.1m };
        private readonly Dictionary<decimal, int> _liczbaMonet = new();

        public Automat()
        {
            foreach (decimal moneta in _przyjmowaneMonety)
                _liczbaMonet[moneta] = 0;
        }

        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            bool czyUdanyParse = decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartoscMonety);

            if (!czyUdanyParse)
            {
                Console.WriteLine("nieudany odczyt");
                return;
            }

            if (!_liczbaMonet.ContainsKey(wartoscMonety))
            {
                Console.WriteLine("zła moneta");
                return;
            }

            konto.Wplac(wartoscMonety);
            _liczbaMonet[wartoscMonety]++;
            Console.WriteLine($"moneta przyjęta: {wartoscMonety}");
        }

        public void PokazMonety()
        {
            decimal suma = 0;

            foreach (decimal nominal in _przyjmowaneMonety)
            {
                int liczba = _liczbaMonet[nominal];
                suma += nominal * liczba;
                Console.WriteLine($"{nominal} zł - {liczba} monet");
            }

            Console.WriteLine($"Łączna wartość: {suma} zł");
        }
    }
}