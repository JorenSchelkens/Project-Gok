using System;

namespace BankDomain
{
    public class Bank
    {
        public int Saldo { get; set; }

        public Bank(int saldo)
        {
            this.Saldo = saldo;
        }

        public int Storten(float geld)
        {
            int munten = OmzettenGeldNaarMunten(geld);
            Saldo += munten;
            return Saldo;
        }

        public int OmzettenGeldNaarMunten(float geld)
        {
            int aantalMunten = Convert.ToInt32(geld * 100);
            return aantalMunten;
        }

        public int Afhalen(int munten)
        {
            Saldo -= munten;
            return Saldo;
        }
        
    }
}
