namespace KontoNaMonety
{
    internal class Program
    {
        // Uruchamia program i pokazuje działanie konta oraz automatu.
        static void Main(string[] args)
        {
            KontoBankowe kontoBankowe = new KontoBankowe();

            Automat automat = new Automat();

            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "0.5");
            automat.WrzucMonete(kontoBankowe, "7");
            automat.WrzucMonete(kontoBankowe, "1");
            automat.WrzucMonete(kontoBankowe, "2");
            automat.WrzucMonete(kontoBankowe, "3");
            automat.WrzucMonete(kontoBankowe, "abc");
            automat.WrzucMonete(kontoBankowe, "abc");

            Console.WriteLine($"Stan konta: {kontoBankowe.StanKonta()} zł");
            Console.WriteLine($"Numer konta: {kontoBankowe.Numer}");
            automat.PokazMonety();
            automat.PokazHistorie();

            Console.WriteLine("Historia operacji:");
            automat.PokazHistorieOperacji();

            KontoBankowe drugieKonto = new KontoBankowe();
            Console.WriteLine($"Numer drugiego konta: {drugieKonto.Numer}");

            Console.WriteLine();
            Console.WriteLine("--- Bankomat ---");

            Bankomat bankomat = new Bankomat();
            bankomat.ZaladujMonety(2, 5);
            bankomat.ZaladujMonety(1, 5);
            bankomat.ZaladujMonety(0.5m, 4);
            bankomat.ZaladujMonety(3, 10);

            bankomat.Wyplac(kontoBankowe, 3.5m);
            bankomat.Wyplac(kontoBankowe, 10);
            bankomat.Wyplac(kontoBankowe, 0.3m);

            Console.WriteLine($"Stan konta: {kontoBankowe.StanKonta()} zł");
            bankomat.PokazPojemnik();
        }
    }
}
