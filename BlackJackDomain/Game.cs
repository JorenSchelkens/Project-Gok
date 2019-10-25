using System;
using System.Collections;
using System.Collections.Generic;
using DefaultClasses.Cards;

namespace BlackJackDomain
{
    
    public class Game
    {
        Random rand = new Random();
        public List<Card> lijstKaartenSpeler = new List<Card>();
        public List<Card> lijstKaartenDealer = new List<Card>();
        public List<Card> cards = CardBuilder.BuildCards();
        public Boolean gewonnen{ get; set; }
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

        public Game()
        {

        }
        
        public void beginSpel()
        {
            int temp = rand.Next(0, cards.Count);
            Card huidigeKaart = cards[temp];
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            som += huidigeKaart.waardeBlackjack;
            lijstKaartenSpeler.Add(huidigeKaart);
            huidigeKaart.waardeBlackjack = rand.Next(1, 10);
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            som += huidigeKaart.waardeBlackjack;
            lijstKaartenSpeler.Add(huidigeKaart);
            if (som == 21)
            {
                gewonnen = true;
            }

            huidigeKaart.waardeBlackjack = rand.Next(1, 10);
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            somDealer += huidigeKaart.waardeBlackjack;
            lijstKaartenDealer.Add(huidigeKaart);
            huidigeKaart.waardeBlackjack = rand.Next(1, 10);
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            somDealer += huidigeKaart.waardeBlackjack;
            lijstKaartenDealer.Add(huidigeKaart);
            if (somDealer == 21)
            {
                gewonnen = false;
            }

        }

        public int extraKaart()
        {
            int temp = rand.Next(0, cards.Count);
            Card huidigeKaart = cards[temp];
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            som += huidigeKaart.waardeBlackjack;
            lijstKaartenSpeler.Add(huidigeKaart);

            if (som > 21)
            {

                for(int i = 0; i < lijstKaartenSpeler.Count; i++)
                {
                    if (lijstKaartenSpeler[i].waardeBlackjack == 11)
                    {
                        lijstKaartenSpeler[i].waardeBlackjack = 1;
                        som -= 10;
                    }
                    else
                    {
                        gewonnen = false;
                    }
                }
                
                    
            }
            if (lijstKaartenSpeler.Count >= 5)
            {
                gewonnen = true;
            }

            return huidigeKaart.waardeBlackjack;
        }

        public int dealer()
        {
            int temp = rand.Next(0, cards.Count);
            Card huidigeKaart = cards[temp];
            if (huidigeKaart.waardeBlackjack == 1)
            {
                huidigeKaart.waardeBlackjack = 11;
            }
            somDealer += huidigeKaart.waardeBlackjack;

            lijstKaartenDealer.Add(huidigeKaart);
            if (somDealer > 21)
            {
                for (int i = 0; i < lijstKaartenDealer.Count; i++)
                {

                    if (lijstKaartenDealer[i].waardeBlackjack == 11)
                    {
                        lijstKaartenDealer[i].waardeBlackjack = 1;
                        somDealer -= 10;
                    }
                    else
                    {
                        gewonnen = true;
                    }

                }

            }

            if (lijstKaartenDealer.Count >= 5)
            {
                gewonnen = true;
            }

            return huidigeKaart.waardeBlackjack;
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
