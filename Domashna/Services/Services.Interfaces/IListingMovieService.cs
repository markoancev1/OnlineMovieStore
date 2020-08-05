using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Domashna.Services.Services.Interfaces
{
    public interface IListingMovieService
    {
        void Add(ListingMovie listingMovie);
        void Edit(ListingMovie listingMovie);
        void Delete(int id);
        void DeleteByMovieId(int movieID);
        ListingMovie GetListingMovieById(int id);
        ListingMovie GetListingMovieByMovieId(int movieID);
        IEnumerable<ListingMovie> GetAllListingMovies();
        IEnumerable<ListingMovie> GetAllListingMovieByUserId(string userId);
    }
}
