using System;

namespace CrashDomain
{
    public class Game
    {

        public double multiplier { get; set; }
        public int muntenIngezet { get; set; }
        public double autoCashOut { get; set; }
        public double totalMultiplier { get; set; } = 0.00;
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

        public Game()
        {
            
        }

        public void VerhoogMultiplier(double seconden)
        {
            multiplier = seconden;
            multiplier = Math.Round(multiplier, 2);
        }
           
        private void genereerRandomGetal()
        {
            Random random = new Random();
            var random1 = new Random().Next(0, 1);
            var random2 = 0.0;

            if(random1 < 0.6)
            {
                random2 = random.NextDouble();
            }
        }
    }
}
