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
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly ILogger<DirectorService> _logger;

        public DirectorService(IDirectorRepository directorRepository, ILogger<DirectorService> logger)
        {
            _directorRepository = directorRepository;
            _logger = logger;
        }
        public void Add(Director director)
        {
            try
            {
                _directorRepository.Add(director);
                _logger.LogInformation(LoggerMessageDisplay.DirectorCreated);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorCreatedNotFound, ex);
            }
        }

        public void Delete(int DirectorID)
        {
            try
            {
                _directorRepository.Delete(DirectorID);
                _logger.LogInformation(LoggerMessageDisplay.DirectorDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorDeletedError, ex);
            }
        }

        public void Edit(Director director)
        {
            try
            {
                _directorRepository.Edit(director);
                _logger.LogInformation(LoggerMessageDisplay.DirectorEdited);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorEditNotFound, ex);
            }
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            var result = _directorRepository.GetAllDirectors();
            return result;
        }

        public Director GetDirectorById(int id)
        {
            var result = _directorRepository.GetDirectorById(id);
            return result;
        }

        public Director GetDirectorByPopularity()
        {
            var result = _directorRepository.GetDirectorByPopularity();
            return result;
        }
    }
}
