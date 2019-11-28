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
        public List<Card> cards;
        private CardBuilder CardBuilder = new CardBuilder();
        public Boolean gewonnen{ get; set; }
        private double inzet{ get; set; }
        public int som { get; set; }
        public int somDealer { get; set; }
        
        

        public Game(double inzet)
        {
            this.cards = this.CardBuilder.BuildCards();
            gewonnen = false;
            this.inzet = inzet;
            som = 0;
            somDealer = 0;
        }

        public Game()
        {
            this.cards = this.CardBuilder.BuildCards();
        }

        public int extraKaart()
        {
            int temp = rand.Next(0, cards.Count);
            Card huidigeKaart = cards[temp];
            cards.RemoveAt(temp);
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
                        som -= 10;
                        lijstKaartenSpeler[i].waardeBlackjack = 1;
                    }
                }
                
                    
            }

            if (lijstKaartenSpeler.Count >= 6 && som <= 21)
            {
                gewonnen = true;
            }else if (som > 21)
            {
                gewonnen = false;
            }

            return huidigeKaart.waardeBlackjack;
        }

        public int dealer()
        {
            
            int temp = rand.Next(0, cards.Count);
            Card huidigeKaart = cards[temp];
            cards.RemoveAt(temp);
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

                }

            }

            if (somDealer > 21 || somDealer < som)
            {
                gewonnen = true;
            }

            if (lijstKaartenDealer.Count >= 6 && somDealer <= 21 || somDealer >= som && somDealer <= 21)
            {
                gewonnen = false;
            }

            if(som == 21 && somDealer < 21)
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
