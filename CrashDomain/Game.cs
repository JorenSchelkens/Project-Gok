using System;
using System.Threading;

namespace CrashDomain
{
    public class Game
    {

        public double multiplier { get; set; }
        public int muntenIngezet { get; set; }
        public double autoCashOut { get; set; }
        public bool spelGedaan { get; set; } = false;
        public Timer timer;

        public Game(double multiplier, int muntenIngezet, double autoCashOut)
        {
            this.multiplier = multiplier;
            this.muntenIngezet = muntenIngezet;
            this.autoCashOut = autoCashOut;
        }

        public void VerhoogMultiplier()
        {
            var random = new Random();
            var totalMultiplier = random.NextDouble();

            timer = new Timer(new TimerCallback(_ =>
            {

            }), null, 1000, 1000);
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
