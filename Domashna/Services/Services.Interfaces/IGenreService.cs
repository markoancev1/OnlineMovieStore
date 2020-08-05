using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Services.Services.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        void Add(Genre genre);
        void Edit(Genre genre);
        void Delete(int GenreID);
        Genre GetGenreById(int id);
    }
}
