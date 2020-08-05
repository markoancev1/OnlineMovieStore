using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Repositories.Repositories.Interfaces
{
    public interface IListingMovieRepository
    {
        void Add(ListingMovie listingMovies);
        void Edit(ListingMovie listingMovies);
        void Delete(int id);
        void DeleteByMovieId(int movieID);
        IEnumerable<ListingMovie> GetAllListingMovies();
        ListingMovie GetListingMovieByMovieId(int movieID);
        ListingMovie GetListingMovieById(int id);
        IEnumerable<ListingMovie> GetAllListingMovieByUserId(string userId);
    }
}
