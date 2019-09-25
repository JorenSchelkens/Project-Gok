using System;

namespace BankDomain
{
    public class Bank
    {
        public Money Money;

        public Bank(int Saldo)
        {
            this.Money = new Money(Saldo);
        }

        public double Storten(double geld)
        {
            int munten = OmzettenGeldNaarMunten(geld);
            this.Money.Storten(munten);
            return munten;
        }

        public int OmzettenGeldNaarMunten(double geld)
        {
            int aantalMunten = Convert.ToInt32(geld * 100);
            return aantalMunten;
        }

        public double OmzettenMuntenNaarGeld(int munten)
        {
            double saldo = Convert.ToDouble(munten / 100);
            return saldo;
        }

        public double Afhalen(int munten)
        {
            double geld = OmzettenMuntenNaarGeld(munten);
            this.Money.MuntenSaldo -= munten;
            return geld;
        }

        
    }
}
