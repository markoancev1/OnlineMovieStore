using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<DirectorRepository> _logger;
        public DirectorRepository(DataContext context, ILogger<DirectorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Director director)
        {
            try
            {
                _context.Directors.Add(director);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorNotCreatedModelStateInvalid, ex);
            }

        }

        public void Delete(int DirectorID)
        {
            try
            {
                Director director = GetDirectorById(DirectorID);
                _context.Directors.Remove(director);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.MovieDeleted);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieDeletedError);
            }
        }

        public void Edit(Director director)
        {
            try
            {
                _context.Directors.Update(director);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.DirectorEdited);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieEditNotFound, ex);
            }
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            var result = _context.Directors.AsEnumerable();
            return result;
        }

        public Director GetDirectorById(int id)
        {
            var result = _context.Directors.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Director GetDirectorByPopularity()
        {
            var result = _context.Directors.Where(x => x.Popularity == true).FirstOrDefault();
            return result;
        }
    }
}
