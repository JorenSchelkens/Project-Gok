using System;
using Xunit;

namespace BankTest
{
    public class BankTest
   {
        BankDomain.Bank bank = new BankDomain.Bank();

        [Fact]
        public void GeldOpUwAccountZettenViaDeBank()
        {
            bank.Storten(500);

            int temp = bank.Money.MuntenSaldo;

            Assert.Equal(600, temp);
        }

        [Fact]
        public void GeldAfhalenVanDeBank()
        {
            bank.Afhalen(50);

            int temp = bank.Money.MuntenSaldo;

            Assert.Equal(50, temp);
        }

        [Fact]
        public void HuidigSaldoAfdrukkenNaAfhalen()
        {
            bank.Afhalen(50);

            Console.WriteLine(bank.Money.MuntenSaldo);
        }
    }
}
