using GOK_SERVER.Data.GOK;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOK_SERVER.Data
{
    public class GebruikersService
    {
        private readonly GOKContext _context;
        public GebruikersService(GOKContext context)
        {
            _context = context;
        }

        public Task<List<Gebruikers>>
            GebruikerLoginAsync(string strCurrentUser, string wachtwoord)
        {
            List<Gebruikers> colGebruiker = new List<Gebruikers>();
            colGebruiker =
                (from gebruiker in _context.Gebruikers 
                 where gebruiker.Gebruikersnaam == strCurrentUser && gebruiker.Wachtwoord == wachtwoord
                 select gebruiker)
                 .ToList();

            return Task.FromResult(colGebruiker);
        }
    }
}