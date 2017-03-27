using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF_V2.Models;
using System.Web.Mvc;
using System.Data.Entity;
using IHFF_V2.Repositories;
using System.Web.UI;

namespace IHFF_V2.Repositories
{
    public class FilmRepository : IFilmRepository
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
                return ctx.Events.Where(film => film.Type.Equals("Film")).GroupBy(x => x.Titel).Select(x => x.FirstOrDefault());
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

        public void AddPicture(byte[] imageData, int Id)
        {
            Event WaarHetPlaatjeMoet = ctx.Events.SingleOrDefault(E => E.Id == Id);
            WaarHetPlaatjeMoet.Poster = imageData;
            ctx.Entry(WaarHetPlaatjeMoet).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        //method that gives one film from two tablel/models
        public DetailFilmViewModel GetDetailedFilm(int Id)
        {
            DetailFilmViewModel DetailedFilmModel = new DetailFilmViewModel();
            
                //get a specific filmevent with given id from filmoverviewe
                DetailedFilmModel.Event = ctx.Events.SingleOrDefault(a => a.Id == Id);

                //get a specific film with eventid
                DetailedFilmModel.Film = ctx.Films.SingleOrDefault(a => a.EventId == Id);

                //get all the times from one movie
                DetailedFilmModel.Tijd = ctx.Events.Where(b => b.Titel == DetailedFilmModel.Event.Titel).Select(a => a.Tijd);

                DetailedFilmModel.RandomEvent = ctx.Events.Where(x => x.Type != "Film").OrderBy(r => Guid.NewGuid()).Take(3);

                //return a model with two models within it
                return DetailedFilmModel;
            
        }
    }
}