using System;

namespace BlackJackDomain
{

    public class Blackjack
    {
        Random rand = new Random();
        private Boolean gewonnen{ get; set; }
        private char kaart { get; set; }
        private double inzet{ get; set; }


        public Blackjack(Boolean gewonnen, char kaart, double inzet)
        {
            this.gewonnen = gewonnen;
            this.kaart = kaart;
            this.inzet = inzet;
        }
        
        

    }
}
