using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Repositories.Repositories.Interfaces
{
    public interface IRentingMovieRepository
    {
        void Add(RentingMovie rentingMovie);
        void Delete(int id);
        void DeleteByMovieId(int movieID);

        RentingMovie GetRentingMovieById(int id);

        IEnumerable<RentingMovie> GetAllItemsInCart();
        IEnumerable<RentingMovie> GetAllItemsInCartByUserId(string userId);
    }
}
