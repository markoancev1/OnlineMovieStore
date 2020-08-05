using Castle.Core.Logging;
using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Repositories.Repositories.Interfaces
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<GenreRepository> _logger;

        public GenreRepository(DataContext context, ILogger<GenreRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Genre genre)
        {
            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.GenreCreated);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreCreatedNotFound, ex);
            }
        }

        public void Delete(int GenreID)
        {
            try
            {
                Genre genre = GetGenreById(GenreID);
                _context.Genres.Remove(genre);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.GenreDeleted); 
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreDeletedError, ex);
            }
        }

        public void Edit(Genre genre)
        {
            try
            {
                _context.Genres.Update(genre);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.GenreEdited);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreEditedError, ex);
            }
        }


        public IEnumerable<Genre> GetAllGenres()
        {
            var result = _context.Genres.AsEnumerable();
            return result;
        }

        public Genre GetGenreById(int id)
        {
            var result = _context.Genres.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
