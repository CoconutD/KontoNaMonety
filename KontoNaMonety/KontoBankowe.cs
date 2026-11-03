namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private static int _następnyNumer = 1;

        public int Numer { get; }

        public KontoBankowe(decimal saldoPoczatkowe = 0)
        {
            if (saldoPoczatkowe < 0)
                throw new ArgumentException("Stan początkowy nie może być ujemny.");

            _saldo = saldoPoczatkowe;
            Numer = _następnyNumer++;
        }

        public decimal StanKonta()
        {
            return _saldo;
        }

        public void Wplac(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Kwota nie może być ujemna.");

            _saldo += kwota;
        }
    }
}