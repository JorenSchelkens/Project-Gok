using System;
using System.Threading;

namespace CrashDomain
{
    public class Game
    {

        public double multiplier { get; set; }
        public int muntenIngezet { get; set; }
        public double autoCashOut { get; set; }
        public double totalMultiplier { get; set; }
        public bool spelGedaan { get; set; } = false;

        public Game(int muntenIngezet, double autoCashOut)
        {
            this.muntenIngezet = muntenIngezet;
            this.autoCashOut = autoCashOut;
        }

        public Game(int muntenIngezet)
        {
            this.muntenIngezet = muntenIngezet;
        }

        public double VerhoogMultiplier()
        {
            multiplier += 0.01;
            multiplier = Math.Round(multiplier, 3);
            return multiplier;
        }

        public bool IsGecrasht(double random)
        {
            if(multiplier == random)
            {
                return true;
            }
            return false;

        }
  
    }
}
