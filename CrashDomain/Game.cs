using System;

namespace CrashDomain
{
    public class Game
    {

        public double multiplier { get; set; }
        public int muntenIngezet { get; set; }
        public double autoCashOut { get; set; }
        public double totalMultiplier { get; set; }
        public bool spelGedaan { get; set; } = false;
        public int delay { get; set; } = 150;  //150 - 10
        public int winstInMunten { get; set; }

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

        public void GeefDoor(double xValue)
        {
            RondAf(xValue);
            VeranderDelay();
        }

        public void RondAf(double xValue)
        {
            multiplier = xValue;
            multiplier = Math.Round(multiplier, 4);
        }

        public void VeranderDelay()
        {
            if (delay <= 10)
            {
                delay = 10;
            }
            else
            {
                delay = -(int)Math.Pow((1.2), multiplier + 25) + 245;
            }

        }

        public void genereerRandomGetal()
        {
            Random random = new Random();
            var random1 = random.NextDouble();

            if (random1 < 0.7)
            {
                totalMultiplier = random.NextDouble();
            }
            else if (random1 < 0.90)
            {
                totalMultiplier = random.NextDouble() + 1;
            }
            else if (random1 < 0.95)
            {
                totalMultiplier = random.NextDouble() * 2 + 2;
            }
            else
            {
                totalMultiplier = random.NextDouble() * 2 + 4;
            }
        }

        public void GeefWinstWeer()
        {
            this.winstInMunten = (int)((muntenIngezet * multiplier) - muntenIngezet);
        }
    }
}