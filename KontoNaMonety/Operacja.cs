namespace KontoNaMonety
{
    internal class Operacja
    {
        public int Numer { get; }
        public string Moneta { get; }
        public string Wynik { get; }

        // Tworzy jeden wpis w historii: co wrzucono i co się z tym stało.
        public Operacja(int numer, string moneta, string wynik)
        {
            Numer = numer;
            Moneta = moneta;
            Wynik = wynik;
        }
    }
}
