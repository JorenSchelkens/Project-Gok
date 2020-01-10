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

        public int Storten(double geld)
        {
            int munten = OmzettenGeldNaarMunten(geld);
            Saldo += munten;
            return Saldo;
        }

        public int OmzettenGeldNaarMunten(double geld)
        {
            int aantalMunten = 0;

            try
            {
                aantalMunten = Convert.ToInt32(geld * 100);
            } 
            catch (SystemException e)
            {
                
            }

            return aantalMunten;
        }

        public int Afhalen(int munten)
        {
            Saldo -= munten;
            return Saldo;
        }
        
    }
}
