using System;

namespace RouletteDomain
{
    public class MogelijkeUitkomst
    {
        public string titel { get; set; }
        public bool isRood { get; set; }
        public bool even { get; set; }
        public bool eersteTwaalf { get; set; }
        public bool tweedeTwaalf { get; set; }
        public bool derdeTwaalf { get; set; }
        public bool tweeToEenEerste { get; set; }
        public bool tweeToEenTweede { get; set; }
        public bool tweeToEenDerde { get; set; }
        public bool eenToAchttien { get; set; }
        public bool negentienTozesendertig { get; set; }
        public bool isNul { get; set; }
        public int nummerWaarde { get; set; }

        public MogelijkeUitkomst(string titel)
        {
            this.titel = titel;
        }
    }
}