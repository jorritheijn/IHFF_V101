using IHFF_V2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IHFF_V2.Repositories
{
    public class SpecialRepository : IspecialRepository
    {
        private ihffContext ctx = new ihffContext();
        public DetailSpecialViewModel GetSpecificSpecial(int Id)
        {
            DetailSpecialViewModel DetailedSpecialModel = new DetailSpecialViewModel();

            //get a specific filmevent with given id from filmoverviewe
            DetailedSpecialModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

            //get a specific film with eventid
            DetailedSpecialModel.Special = ctx.Specials.SingleOrDefault(a => a.EventId == Id);

            //get RandomEvent
            DetailedSpecialModel.RandomEvents = ctx.Events.Where(x => x.Type != "Special").OrderBy(r => Guid.NewGuid()).Take(3);

            //return a model with two models within it
            return DetailedSpecialModel;
        }

        public IEnumerable<Event> AlleSpecialsEnkel
        {
            get
            {
                return ctx.Events.Where(film => film.Type.Equals("Special")).GroupBy(x => x.Titel).Select(x => x.FirstOrDefault());
            }
        }

        public IEnumerable<Event> AlleSpecials
        {
            get
            {
                IEnumerable<Event> allefilms = ctx.Events.Where(film => film.Type.Equals("Special"));
                return allefilms;
            }
        }


        /*returned alle events van het type film die een zoekwoord bevatten*/
        public IEnumerable<Event> SpecialsOpZoekWoord(string zoekwoord)
        {
            IEnumerable<Event> SpecialsOpZoekWoord = AlleSpecials.Where(s => s.Titel.Contains(zoekwoord));
            return SpecialsOpZoekWoord;
        }

        public IEnumerable<Event> SpecailsOpZoekWoord(string zoekwoord, IEnumerable<Event> HuidgeSelectie)
        {
            IEnumerable<Event> SpecialsOpZoekWoord = HuidgeSelectie.Where(s => s.Titel.Contains(zoekwoord));
            return SpecialsOpZoekWoord;
        }

        /*returned alleen de films die af worden gespeeld op een speciafieke dag*/
        public IEnumerable<Event> SpecialsOpDag(string dag)
        {
            DayOfWeek AangeklikteDag = DayOfWeek.Monday;
            switch (dag)
            {
                case "maandag":
                    AangeklikteDag = DayOfWeek.Monday;
                    break;

                case "dinsdag":
                    AangeklikteDag = DayOfWeek.Tuesday;
                    break;

                case "woensdag":
                    AangeklikteDag = DayOfWeek.Wednesday;
                    break;

                case "donderdag":
                    AangeklikteDag = DayOfWeek.Thursday;
                    break;

                case "vrijdag":
                    AangeklikteDag = DayOfWeek.Friday;
                    break;

                case "zaterdag":
                    AangeklikteDag = DayOfWeek.Saturday;
                    break;

                case "zondag":
                    AangeklikteDag = DayOfWeek.Sunday;
                    break;

            }
            return AlleSpecials.Where(s => s.Tijd.Value.DayOfWeek.Equals(AangeklikteDag));
        }

        internal void EditSpecial(Special special)
        {
            ctx.Entry(special).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}