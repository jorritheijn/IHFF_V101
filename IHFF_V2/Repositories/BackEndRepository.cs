using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class BackEndRepository : IBackEndRepository
    {
        private ihffContext ctx = new ihffContext();
        public Medewerker GetAccount(string gebruikersnaam, string wachtwoord)
        {
            Medewerker account = ctx.Medewerker.Where(x => x.Gebruikersnaam == gebruikersnaam && x.Wachtwoord == wachtwoord).SingleOrDefault();

            if (account != null)
            {
                return account;
            }
            return null;
        }
    }
}