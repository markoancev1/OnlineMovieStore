using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domashna.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public readonly DataContext _context;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(DataContext context, ILogger<MovieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.MovieCreated);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieCreatedNotFound, ex);
            }
        }

        public void Delete(int movieID)
        {
            try { 
            Movie movie = GetMovieById(movieID);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            _logger.LogInformation(LoggerMessageDisplay.MovieDeleted);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieDeletedError, ex);
            }
        }

        public void Edit(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.MovieEdited);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieEditedError, ex);
            }
        }

        public Movie GetMovieById(int id)
        {
                var result = _context.Movies.FirstOrDefault(x => x.Id == id);
                return result;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var result = _context.Movies.AsEnumerable();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByDateAccending()
        {
            var result = _context.Movies.AsEnumerable().OrderBy(x => x.YearOfRelease);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByDateDescending()
        {
            var result = _context.Movies.AsEnumerable().OrderByDescending(x => x.YearOfRelease);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByGeoLocationCountry(string country)
        {
            var result = _context.Movies.AsEnumerable().Where(x => x.Country == country);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByPriceAccending()
        {
            var result = _context.Movies.AsEnumerable().OrderBy(x => x.Price);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByPriceDescending()
        {
            var result = _context.Movies.AsEnumerable().OrderByDescending(x => x.Price);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByGenre(Genre genre)
        {
            var result = _context.Movies.AsEnumerable().Where(x => x.Genre == genre);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByUserId(int userId)
        {
            var result = _context.Movies.AsEnumerable().Where(x => x.UserId == userId);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesForListingMovie()
        {
            var result = _context.Movies.AsEnumerable();
            return result;
        }

        public IQueryable<Movie> GetAllMoviesQueryable()
        {
            var result = _context.Movies.AsQueryable();
            return result;
        }

        public IEnumerable<Movie> GetTopPopularMovie()
        {
            var result = _context.Movies.AsEnumerable().OrderByDescending(x => x.SoldItems).Take(6);
            return result;
        }

        public IEnumerable<Movie> GetTopPopularMoviesByBestSellingDirector(int directorId)
        {
            var result = _context.Movies.AsEnumerable().Where(x => x.DirectorID == directorId);
            return result;

        }
    }
}
