using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Domashna.Services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Services
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieRepository movieRepository, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }

        public void Add(Movie movie)
        {
            try
            {
                _movieRepository.Add(movie);
                _logger.LogInformation(LoggerMessageDisplay.MovieCreated);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieCreatedNotFound, ex);
            }
        }

        public void Delete(int movieID)
        {
            try
            {
                _movieRepository.Delete(movieID);
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
                _movieRepository.Edit(movie);
                _logger.LogInformation(LoggerMessageDisplay.MovieEdited);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieEditNotFound, ex);
            }
        }

        public Movie GetMovieById(int id)
        {
            var result = _movieRepository.GetMovieById(id);
            return result;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var result = _movieRepository.GetAllMovies();
            return result;
        }


        public IQueryable<Movie> GetAllMovieQueryable()
        {
            var result = _movieRepository.GetAllMoviesQueryable();
            return result;
        }

        public IEnumerable<Movie> GetTopPopularMovie()
        {
            var result = _movieRepository.GetTopPopularMovie();
            return result;
        }

        public IEnumerable<Movie> GetTopPopularMoviesByBestSellingDirector(int directorId)
        {
            var result = _movieRepository.GetTopPopularMoviesByBestSellingDirector(directorId);
            return result;

        }

        public IEnumerable<Movie> GetAllMoviesForListingMovie()
        {
            var result = _movieRepository.GetAllMoviesForListingMovie();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByDateAccending()
        {
            var result = _movieRepository.GetAllMoviesByDateAccending();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByDateDescending()
        {
            var result = _movieRepository.GetAllMoviesByDateDescending();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByGeoLocationCountry(string country)
        {
            var result = _movieRepository.GetAllMoviesByGeoLocationCountry(country);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByPriceAccending()
        {
            var result = _movieRepository.GetAllMoviesByPriceAccending();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByPriceDescending()
        {
            var result = _movieRepository.GetAllMoviesByPriceDescending();
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByGenre(Genre genre)
        {
            var result = _movieRepository.GetAllMoviesByGenre(genre);
            return result;
        }

        public IEnumerable<Movie> GetAllMoviesByUserId(int userID)
        {
            var result = _movieRepository.GetAllMoviesByUserId(userID);
            return result;
        }
    }
}
