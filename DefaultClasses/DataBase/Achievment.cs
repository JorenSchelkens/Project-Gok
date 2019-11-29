using System;

namespace DefaultClasses.DataBase
{
    public class Achievment
    {
        public int Nummer { get; set; }
        public string AchievementOmschrijving { get; set; }
        public int Spelernummer { get; set; }
        public int AantalGewonnenGames { get; set; }
        public int Beloning { get; set; }

        public event EventHandler StateChanged;

        public void Refresh()
        {
            this.StateHasChanged();
        }

        private void StateHasChanged()
        {
            this.StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}