namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private static int _następnyNumer = 1;

        public int Numer { get; }

        // Tworzy nowe konto, ustawia stan początkowy i przydziela numer konta.
        public KontoBankowe(decimal saldoPoczatkowe = 0)
        {
            if (saldoPoczatkowe < 0)
                throw new ArgumentException("Stan początkowy nie może być ujemny.");

            _saldo = saldoPoczatkowe;
            Numer = _następnyNumer++;
        }

        // Zwraca aktualną kwotę znajdującą się na koncie.
        public decimal StanKonta()
        {
            return _saldo;
        }

        // Wpłaca podaną kwotę na konto.
        public void Wplac(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Kwota nie może być ujemna.");

            _saldo += kwota;
        }
    }
}  