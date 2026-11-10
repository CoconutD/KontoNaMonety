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

            KontoBankowe drugieKonto = new KontoBankowe();
            Console.WriteLine($"Numer drugiego konta: {drugieKonto.Numer}");
        }
    }
}
