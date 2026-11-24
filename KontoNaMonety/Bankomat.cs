namespace KontoNaMonety
{
    internal class Bankomat
    {
        private readonly int[] _pojemnik = new int[Automat.Nominaly.Length];

        // Serwisant ładuje do bankomatu monety jednego nominału.
        public void ZaladujMonety(decimal nominal, int ilosc)
        {
            if (ilosc <= 0)
            {
                Console.WriteLine("liczba monet musi być większa od zera");
                return;
            }

            for (int i = 0; i < Automat.Nominaly.Length; i++)
            {
                if (Automat.Nominaly[i] == nominal)
                {
                    _pojemnik[i] += ilosc;
                    Console.WriteLine($"załadowano {ilosc} monet po {nominal} zł");
                    return;
                }
            }

            Console.WriteLine($"bankomat nie obsługuje monet {nominal} zł");
        }

        // Wypłaca kwotę z konta, tylko gdy da się wydać ją dokładnie.
        public void Wyplac(KontoBankowe konto, decimal kwota)
        {
            Console.WriteLine($"wypłata {kwota} zł:");

            if (kwota <= 0)
            {
                Console.WriteLine("odmowa - kwota musi być większa od zera");
                return;
            }

            if (kwota > konto.StanKonta())
            {
                Console.WriteLine("odmowa - za mało pieniędzy na koncie");
                return;
            }

            int[] doWydania = new int[Automat.Nominaly.Length];
            decimal reszta = kwota;

            for (int i = 0; i < Automat.Nominaly.Length; i++)
            {
                while (reszta >= Automat.Nominaly[i] && doWydania[i] < _pojemnik[i])
                {
                    doWydania[i]++;
                    reszta -= Automat.Nominaly[i];
                }
            }

            if (reszta != 0)
            {
                Console.WriteLine("odmowa - bankomat nie może wydać dokładnie tej kwoty");
                return;
            }

            if (!konto.Wyplac(kwota))
            {
                Console.WriteLine("odmowa - wypłata z konta się nie udała");
                return;
            }

            for (int i = 0; i < Automat.Nominaly.Length; i++)
            {
                if (doWydania[i] > 0)
                {
                    _pojemnik[i] -= doWydania[i];
                    Console.WriteLine($"wydano {doWydania[i]} x {Automat.Nominaly[i]} zł");
                }
            }
        }

        // Wyświetla monety w bankomacie i ich łączną wartość.
        public void PokazPojemnik()
        {
            decimal suma = 0;

            for (int i = 0; i < Automat.Nominaly.Length; i++)
            {
                suma += Automat.Nominaly[i] * _pojemnik[i];
                Console.WriteLine($"{Automat.Nominaly[i]} zł - {_pojemnik[i]} monet");
            }

            Console.WriteLine($"Razem w bankomacie: {suma} zł");
        }
    }
}
