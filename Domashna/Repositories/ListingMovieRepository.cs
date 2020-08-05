using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Repositories
{
    public class ListingMovieRepository : IListingMovieRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ListingMovieRepository> _logger;

        public ListingMovieRepository(DataContext context, ILogger<ListingMovieRepository> logger)
        {
                _context = context;
                _logger = logger;
        }

        public void Add(ListingMovie listingMovie)
        {
            try
            {
                _context.ListingMovies.Add(listingMovie);
                _context.SaveChanges();
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
                var listingMovie = GetListingMovieById(id);
                _context.ListingMovies.Remove(listingMovie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieDeleted);
            }catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieDeletedError, ex);
            }
        }

        public void DeleteByMovieId(int Id)
        {
            var listingMovie = GetListingMovieByMovieId(Id);
            _context.ListingMovies.Remove(listingMovie);
            _context.SaveChanges();
        }

        public void Edit(ListingMovie listingMovie)
        {
            try
            {
                _context.ListingMovies.Update(listingMovie);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieEdited);
            }catch(Exception ex)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieEditedError, ex);
            }
        }

        // Important
        public IEnumerable<ListingMovie> GetAllListingMovieByUserId(string userId)
        {

            var result = _context.ListingMovies.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.MovieId);
            return result;
        }

        public IEnumerable<ListingMovie> GetAllListingMovies()
        {
            var result = _context.ListingMovies.AsEnumerable();
            return result;
        }

        public ListingMovie GetListingMovieById(int id)
        {
            var result = _context.ListingMovies.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public ListingMovie GetListingMovieByMovieId(int movieID)
        {
            var result = _context.ListingMovies.FirstOrDefault(x => x.MovieId == movieID);
            return result;
        }

    }
}
