using System;

namespace HogerEnLagerDomain
{

    public class HogerLager
    {

        private int eigenKaart { get; set; }
        private int computerKaart { get; set; }
        private int hoogsteKaart { get; set; }


        public int BerekenHoogsteKaart()
        {
            if(eigenKaart > computerKaart)
            {
                hoogsteKaart = eigenKaart;
            }
            else if(eigenKaart == computerKaart)
            {
                hoogsteKaart = eigenKaart;
            }
            else
            {
                hoogsteKaart = computerKaart;
            }

            return hoogsteKaart;

        }





    }


}
