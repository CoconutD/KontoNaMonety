  using System.Globalization;

namespace KontoNaMonety
{
    internal class Automat
    {
        private readonly decimal[] _przyjmowaneMonety = { 5, 2, 1, 0.5m, 0.2m, 0.1m };
        private readonly int[] _liczbaMonet = new int[6];
        private readonly int[] _limityMonet = { 3, 3, 3, 3, 3, 3 };
        private int _liczbaNieudanychOdczytow;
        private int _liczbaOdrzuconychMonet;

        // Tworzy automat i ustawia liczbę każdej monety na zero.
        public Automat()
        {
            // Tablica _liczbaMonet ma 0 w każdym elemencie, więc nie trzeba jej inicjalizowac
        }

        // Odczytuje monetee sprawdza jej nominal i wplaca ja na konto.
        public void WrzucMonete(KontoBankowe konto, string moneta)
        {
            bool czyUdanyParse = decimal.TryParse(moneta, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal wartoscMonety);

            if (!czyUdanyParse)
            {
                _liczbaNieudanychOdczytow++;
                Console.WriteLine("nieudany odczyt");
                return;
            }

            int numerMonety = -1;

            for (int i = 0; i < _przyjmowaneMonety.Length; i++)
            {
                if (_przyjmowaneMonety[i] == wartoscMonety)
                {
                    numerMonety = i;
                    break;
                }
            }

            if (numerMonety == -1)
            {
                _liczbaOdrzuconychMonet++;
                Console.WriteLine("zła moneta");
                return;
            }

            if (_liczbaMonet[numerMonety] >= _limityMonet[numerMonety])
            {
                _liczbaOdrzuconychMonet++;
                Console.WriteLine($"limit monet {wartoscMonety} zł został osiągnięty");
                return;
            }

            konto.Wplac(wartoscMonety);
            _liczbaMonet[numerMonety]++;
            Console.WriteLine($"moneta przyjęta: {wartoscMonety}");
        }

        // Wyświetla liczbę monet każdego nominału oraz ich łączną wartość.
        public void PokazMonety()
        {
            decimal suma = 0;

            for (int i = 0; i < _przyjmowaneMonety.Length; i++)
            {
                decimal nominal = _przyjmowaneMonety[i];
                suma += nominal * _liczbaMonet[i];
                Console.WriteLine($"{nominal} zł - {_liczbaMonet[i]} monet");
            }

            Console.WriteLine($"Łączna wartość: {suma} zł");
        }

        // Wyświetla liczbe nieudanych odczytów i odrzuconych monet.
        public void PokazHistorie()
        {
            Console.WriteLine($"Nieudane odczyty: {_liczbaNieudanychOdczytow}");
            Console.WriteLine($"Odrzucone monety: {_liczbaOdrzuconychMonet}");
        }
    }
}