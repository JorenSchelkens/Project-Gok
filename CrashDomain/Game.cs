using System;

namespace CrashDomain
{
    public class Game
    {

        public double multiplier { get; set; }
        public int muntenIngezet { get; set; }
        public double autoCashOut { get; set; }
        public double totalMultiplier { get; set; } = 10.00;
        public bool spelGedaan { get; set; } = false;
        public int delay { get; set; } = 150;  //150 - 10

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
            multiplier = Math.Round(multiplier, 2);
        }

        public void VeranderDelay()
        {
            if(delay <= 10)
            {
                delay = 10;
            } else
            {
                delay = (int)Math.Pow((-1.2), multiplier) + 151;
            }
            
        }

        private void genereerRandomGetal()
        {
            Random random = new Random();
            var random1 = random.NextDouble();
            var winst = 0.0;

            if (random1 < 0.7)
            {
                winst = random.Next(400000, 600000); // * inzet

            }
            else if (random1 < 0.90)
            {
                winst = random.NextDouble(); // * inzet

            }
            else if (random1 < 0.95)
            {
                winst = random.NextDouble(); // * inzet

            }
            else
            {
                winst = random.NextDouble(); // * inzet

            }
        }
    }
}
