using Castle.Core.Logging;
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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<MovieService> _logger;

        public GenreService(IGenreRepository genreRepository, ILogger<MovieService> logger)
        {
            _genreRepository = genreRepository;
            _logger = logger;
        }
        public void Add(Genre genre)
        {
            try
            {
                _genreRepository.Add(genre);
                _logger.LogInformation(LoggerMessageDisplay.GenreCreated);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreCreatedNotFound, ex);
            }
        }

        public void Delete(int GenreID)
        {
            try
            {
                _genreRepository.Delete(GenreID);
                _logger.LogInformation(LoggerMessageDisplay.GenreDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreDeletedError, ex);
            }
        }

        public void Edit(Genre genre)
        {
            try
            {
                _genreRepository.Edit(genre);
                _logger.LogInformation(LoggerMessageDisplay.GenreEdited);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreEditedError, ex);
            }
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            var result = _genreRepository.GetAllGenres();
            return result;
        }

        public Genre GetGenreById(int id)
        {
            var result = _genreRepository.GetGenreById(id);
            return result;
        }
    }
}
