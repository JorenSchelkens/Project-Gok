using System;

namespace BankDomain
{
    public class Money
    {
        public int MuntenSaldo { get; set; }

        public Money(int MuntenSaldo)
        {
            this.MuntenSaldo = MuntenSaldo;
        }

        public void Storten(int munten)
        {
            this.MuntenSaldo += munten;
        }


    }
}
