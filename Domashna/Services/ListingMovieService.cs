using Castle.Core.Logging;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Services
{
    public class ListingMovieService : IListingMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IListingMovieRepository _listingMovieRepository;
        private UserManager<IdentityUser> _userManager;
        private ILogger<ListingMovieService> _logger;

        public ListingMovieService(
            IMovieRepository movieRepository,
            IListingMovieRepository listingMovieRepository,
            UserManager<IdentityUser> userManager,
            ILogger<ListingMovieService> logger)
        {
            _movieRepository = movieRepository;
            _listingMovieRepository = listingMovieRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public void Add(ListingMovie listingMovie)
        {
            try
            {
                _listingMovieRepository.Add(listingMovie);
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieCreated);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieCreatedNotFound, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _listingMovieRepository.Delete(id);
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieDeletedError, ex);
            }
        }

        public void DeleteByMovieId(int movieID)
        {
            _listingMovieRepository.DeleteByMovieId(movieID);
        }

        public void Edit(ListingMovie listingMovie)
        {
            try
            {
                _listingMovieRepository.Edit(listingMovie);
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieEdited);
            }catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieEditedError, ex);
            }
        }

        public IEnumerable<ListingMovie> GetAllListingMovieByUserId(string userId)
        {
            var result = _listingMovieRepository.GetAllListingMovieByUserId(userId);
            return result;
        }

        public IEnumerable<ListingMovie> GetAllListingMovies()
        {
            var result = _listingMovieRepository.GetAllListingMovies();
            return result;
        }

        public ListingMovie GetListingMovieByMovieId(int movieID)
        {
            var result = _listingMovieRepository.GetListingMovieByMovieId(movieID);
            return result;
        }

        public ListingMovie GetListingMovieById(int id)
        {
            var result = _listingMovieRepository.GetListingMovieById(id);
            return result;
        }
    }
}
