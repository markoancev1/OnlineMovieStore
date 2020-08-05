using Castle.Core.Logging;
using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domashna.Repositories
{
    public class RentingMovieRepository : IRentingMovieRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<RentingMovieRepository> _logger;

        public RentingMovieRepository(DataContext context, ILogger<RentingMovieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(RentingMovie rentingMovie)
        {
            try
            {
                _context.RentingMovies.Add(rentingMovie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieCreated);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieCreatedNotFound, ex);
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                var rentingMovie = GetRentingMovieById(id);
                _context.RentingMovies.Remove(rentingMovie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieDeleted);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieDeletedError, ex);
            }
        }

        public void DeleteByMovieId(int Id)
        {
            var rentingMovie = GetRentingMovieByMovieId(Id);
            _context.RentingMovies.Remove(rentingMovie);
            _context.SaveChanges();
        }

        public IEnumerable<RentingMovie> GetAllItemsInCart()
        {
            var result = _context.RentingMovies.AsEnumerable();
            return result;
        }

        public IEnumerable<RentingMovie> GetAllItemsInCartByUserId(string userId)
        {

            var result = _context.RentingMovies.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.MovieId);
            return result;
        }

        public RentingMovie GetRentingMovieById(int id)
        {
            var result = _context.RentingMovies.FirstOrDefault(x => x.Id == id);
            return result;
        }


        public RentingMovie GetRentingMovieByMovieId(int movieID)
        {
            var result = _context.RentingMovies.FirstOrDefault(x => x.MovieId == movieID);
            return result;
        }
    }
}
