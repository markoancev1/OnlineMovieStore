using Domashna.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domashna.Models
{
    public class RentingMovieViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime YearOfRelease { get; set; }
        public double Price { get; set; }
        public double IMBDScore { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        public string MainPhotoURL { get; set; }
        public int SoldItems { get; set; }


        public string DirectorName { get; set; }
        public int DirectorID { get; set; }



        public string GenreName { get; set; }
        public int GenreID { get; set; }


        public double ListingMovieTotalPrice { get; set; }


        public double SubTotal { get; set; }
        public double ShippingTotal { get; set; }
        public double TotalPrice { get; set; }
        public double AddToCartTotalCounter { get; set; }


        public IEnumerable<Movie> AllMovies { get; set; }
        public IEnumerable<Movie> AllMoviesFromListingMovieByLoggedInUser { get; set; }
        public IEnumerable<Movie> AllMoviesAddedToCartByLoggedInUser { get; set; }
    }
}
