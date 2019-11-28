namespace DefaultClasses.DataBase
{
    public class GiftCard
    {
        public int Nummer { get; set; }
        public string InvulCode { get; set; }
        public int UsesLeft { get; set; }
        public int KortingProcent { get; set; }
        public int TeOntvangenSaldo { get; set; }

        public bool isSaldo()
        {
            return (KortingProcent == -1) ? true : false;
        }

    }
}