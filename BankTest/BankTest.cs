using System;
using Xunit;
using Bank;

namespace BankTest
{
    public class BankTest
   {
        Bank.Bank bank = new Bank.Bank();

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
    }
}
