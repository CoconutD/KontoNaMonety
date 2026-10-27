using System;
using System.Collections.Generic;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private string _numer;

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public KontoBankowe(string numer, decimal saldoPoczatkowe)
        {
            _saldo = saldoPoczatkowe;
            _numer = numer;
        }

        public string StanKonta()
        {
            return $"Stan konta: {Saldo} zł";
        }
        public void Wplac(decimal kwota)
        {
            {
                if (kwota < 0)
                    throw new ArgumentException("Kwota nie może być ujemna.");
                _saldo += kwota;
            }
        }
    }
}