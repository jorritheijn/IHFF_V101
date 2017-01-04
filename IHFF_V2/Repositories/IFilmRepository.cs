using System;
using System.Collections.Generic;
using IHFF_V2.Models;
using System.Linq;
using System.Web;

namespace IHFF_V2.Repositories
{
    interface IFilmRepository
    {
        IEnumerable<Event> FilmsOpZoekWoord(string zoekwoord);
        IEnumerable<Event> FilmsOpZoekWoord(string zoekwoord, IEnumerable<Event> HuidgeSelectie);
        IEnumerable<Event> FilmsOpDag(string dag);
        void AddPicture(byte[] imageData, int Id);
        DetailFilmViewModel GetFilm(int Id);
    }
}