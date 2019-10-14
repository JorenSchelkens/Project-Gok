using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJackDomain
{
    
    public class Game
    {
        Random rand = new Random();
        ArrayList lijstKaartenSpeler = new ArrayList();
        ArrayList lijstKaartenDealer = new ArrayList();
        private Boolean gewonnen{ get; set; }
        private double inzet{ get; set; }
        private int som { get; set; }
        private int somDealer { get; set; }
        
        

        public Game(double inzet)
        {
            gewonnen = false;
            this.inzet = inzet;
            som = 0;
            somDealer = 0;
        }
        
        public void beginSpel()
        {
            int huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            som += huidigeKaart;
            lijstKaartenSpeler.Add(huidigeKaart);
            huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            som += huidigeKaart;
            lijstKaartenSpeler.Add(huidigeKaart);
            if (som == 21)
            {
                gewonnen = true;
            }
            
            huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            somDealer += huidigeKaart;
            lijstKaartenDealer.Add(huidigeKaart);
            huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            somDealer += huidigeKaart;
            lijstKaartenDealer.Add(huidigeKaart);
            if (somDealer == 21)
            {
                gewonnen = false;
            }

        }

        public int extraKaart()
        {
            int huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            som += huidigeKaart;
            lijstKaartenSpeler.Add(huidigeKaart);

            if (som > 21)
            {
                if (lijstKaartenSpeler.Contains(11))
                {
                    lijstKaartenSpeler[lijstKaartenSpeler.IndexOf(11)] = 1;
                    som -= 10;
                }
                else
                {
                    gewonnen = false;
                }
                    
            }
            return huidigeKaart;
        }

        public int dealer()
        {
            int huidigeKaart = rand.Next(1, 10);
            if (huidigeKaart == 1)
            {
                huidigeKaart = 11;
            }
            somDealer += huidigeKaart;

            lijstKaartenDealer.Add(huidigeKaart);
            if (somDealer > 21)
            {
                if (lijstKaartenDealer.Contains(11))
                {
                    lijstKaartenDealer[lijstKaartenDealer.IndexOf(11)] = 1;
                    somDealer -= 10;
                }
                else
                {
                    gewonnen = true;
                }

            }
            return huidigeKaart;
        }

        public double winnaar()
        {
            if (gewonnen)
            {
                inzet *= 2;
            }
            else
            {
                inzet = 0;
            }
            return inzet;
        }
    }
}
