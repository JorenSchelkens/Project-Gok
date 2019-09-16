using System;

namespace Bank
{
    public class Bank
    {
        Money Money = new Money();

        public void Storten(int munten)
        {
            this.Money.Storten(munten);
        }

        public int Omzetten(double geld)
        {
            int aantalMunten = Convert.ToInt32(geld * 100);
            return aantalMunten;
        }

        public void Afhalen(int munten)
        {
            this.Money.MuntenSaldo -= munten;
        }
    }
}
