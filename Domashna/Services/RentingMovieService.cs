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
    public class RentingMovieService : IRentingMovieService
    {
        private readonly IRentingMovieRepository _rentingMovieRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IListingMovieRepository _listingMovieRepository;
        private UserManager<IdentityUser> _userManager;
        private ILogger<RentingMovieService> _logger;

        public RentingMovieService(
            IRentingMovieRepository rentingMovieRepository,
            IMovieRepository movieRepository,
            IListingMovieRepository listingMovieRepository,
            UserManager<IdentityUser> userManager,
            ILogger<RentingMovieService> logger
            )
        {
            _rentingMovieRepository = rentingMovieRepository;
            _movieRepository = movieRepository;
            _listingMovieRepository = listingMovieRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public void Add(RentingMovie rentingMovie)
        {
            try
            {
                _rentingMovieRepository.Add(rentingMovie);
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieCreated);
            }catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieCreatedNotFound, ex);

            }
        }

        public void Delete(int id)
        {
            try
            {
                _rentingMovieRepository.Delete(id);
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieDeleted);
            }catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieDeletedError, ex);
            }
        }

        public void DeleteByMovieId(int movieID)
        {
            _rentingMovieRepository.DeleteByMovieId(movieID);
        }

        public IEnumerable<RentingMovie> GetAllItemsInCart()
        {
            var result = _rentingMovieRepository.GetAllItemsInCart();
            return result;
        }

        public IEnumerable<RentingMovie> GetAllItemsInCartByUserId(string userId)
        {
            var result = _rentingMovieRepository.GetAllItemsInCartByUserId(userId);
            return result;
        }

        public RentingMovie GetRentingMovieById(int id)
        {
            var result = _rentingMovieRepository.GetRentingMovieById(id);
            return result;
        }

    }
}
