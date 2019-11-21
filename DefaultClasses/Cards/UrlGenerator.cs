using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultClasses.Cards
{
    public class UrlGenerator
    {
        public List<string> GenerateUrls()
        {
            List<string> cards = new List<string>();

            string baseUrl = "img/Kaarten/";
            string soort = "";
            string index;
            string url;

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        soort = "C";
                        break;
                    case 1:
                        soort = "D";
                        break;
                    case 2:
                        soort = "H";
                        break;
                    case 3:
                        soort = "S";
                        break;
                }

                for (int j = 1; j <= 13; j++)
                {
                    switch (j)
                    {
                        case 1:
                            index = "A";
                            break;
                        case 11:
                            index = "J";
                            break;
                        case 12:
                            index = "Q";
                            break;
                        case 13:
                            index = "K";
                            break;
                        default:
                            index = j.ToString();
                            break;
                    }

                    url = baseUrl + soort + index + ".png";
                    cards.Add(url);

                }

            }

            return cards;
        }

    }
}
