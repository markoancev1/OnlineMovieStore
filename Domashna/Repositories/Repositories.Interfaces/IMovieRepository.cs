using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domashna.Repositories.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        void Add(Movie movie);
        void Edit(Movie movie);
        void Delete(int movieID);
        Movie GetMovieById(int id);
        IQueryable<Movie> GetAllMoviesQueryable();

      
        IEnumerable<Movie> GetAllMoviesByUserId(int userId);
        IEnumerable<Movie> GetAllMoviesByDateDescending();
        IEnumerable<Movie> GetAllMoviesByDateAccending();
       
        IEnumerable<Movie> GetAllMoviesByPriceAccending();
        IEnumerable<Movie> GetAllMoviesByPriceDescending();
        IEnumerable<Movie> GetAllMoviesByGeoLocationCountry(string country);
        IEnumerable<Movie> GetAllMoviesByGenre(Genre genre);
        IEnumerable<Movie> GetAllMoviesForListingMovie();
        IEnumerable<Movie> GetTopPopularMovie();
        IEnumerable<Movie> GetTopPopularMoviesByBestSellingDirector(int directorId);
    }
}
