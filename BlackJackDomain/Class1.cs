using System;

namespace BlackJackDomain
{
    public class Blackjack
    {

        private int[] lijstKaarten { get; set; }
        private int som { get; set; }


        public Blackjack()
        {

        }

        public Boolean Hit()
        {
            Boolean bust = false;

            if(som > 21)
            {
                bust = true;
            }

            return bust;
        }
    }
}
