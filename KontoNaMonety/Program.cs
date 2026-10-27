namespace KontoNaMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie konta
            KontoBankowe kontoBankowe = new KontoBankowe("1234567890", 100m);

            // Tworzenie automatu do wpłat
            Automat automat = new Automat();

            automat.WrzucMonete(kontoBankowe, "0.5");

            Console.WriteLine(kontoBankowe.StanKonta()); // Wyświetlamy stan konta (jeszcze nie zrobione)

        }
    }
}
