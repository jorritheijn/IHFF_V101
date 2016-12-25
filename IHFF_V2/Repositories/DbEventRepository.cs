using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;

namespace IHFF_V2.Repositories
{
    public class FilmRepository
    {
        private ihffContext ctx = new ihffContext();

        public IEnumerable<Event> AlleFilms
        {
            get
            {

                IEnumerable<Event> allefilms = ctx.Events.Where(film => film.Type.Equals("Film"));
                return allefilms;
            }
        }

        public IEnumerable<Event> AlleFilmsEnkel
        {
            get
            {
               return AlleFilms.GroupBy(p => p.Titel).Select(g => g.First());
            }
        }


        /*returned alle events van het type film die een zoekwoord bevatten*/ 
        public IEnumerable<Event> FilmsOpZoekWoord(string zoekwoord) 
        {
            IEnumerable<Event> FilmsOpZoekWoord = AlleFilms.Where(s => s.Titel.Contains(zoekwoord));
            return FilmsOpZoekWoord;
        }

        public IEnumerable<Event> FilmsOpZoekWoord(string zoekwoord, IEnumerable<Event> HuidgeSelectie)
        {
            IEnumerable<Event> FilmsOpZoekWoord = HuidgeSelectie.Where(s => s.Titel.Contains(zoekwoord));
            return FilmsOpZoekWoord;
        }

        /*returned alleen de films die af worden gespeeld op een speciafieke dag*/
        public IEnumerable<Event> FilmsOpDag(string dag)
        {
            DayOfWeek AangeklikteDag = DayOfWeek.Monday;
            switch (dag)
            {
                case "maandag": AangeklikteDag = DayOfWeek.Monday;
                    break;

                case "dinsdag": AangeklikteDag = DayOfWeek.Tuesday;
                    break;

                case "woensdag": AangeklikteDag = DayOfWeek.Wednesday;
                    break;

                case "donderdag": AangeklikteDag = DayOfWeek.Thursday;
                    break;

                case "vrijdag": AangeklikteDag = DayOfWeek.Friday;
                    break;

                case "zaterdag": AangeklikteDag = DayOfWeek.Saturday;
                    break;

                case "zondag": AangeklikteDag = DayOfWeek.Sunday;
                    break;  
                    
            }
            return AlleFilms.Where(s => s.Tijd.Value.DayOfWeek.Equals(AangeklikteDag));
        }
    }
}