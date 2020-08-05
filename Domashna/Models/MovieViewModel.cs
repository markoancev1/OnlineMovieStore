using Domashna.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domashna.Models
{
    public class MovieViewModel
    {
        [key]
        [StringLength(350)]
        public string Title { get; set; }
        public DateTime YearOfRelease { get; set; }
        public int UserId { get; set; }
        public double IMBDScore { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        public string MainPhotoURL { get; set; }
        public int SoldItems { get; set; }



        // Director Data
        [StringLength(350)]
        public string DirectorName { get; set; }
        public string CreateDirectorName { get; set; }
        public string DirectorCountry { get; set; }
        public string CreateDirectorCountry { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }
        public IEnumerable<SelectListItem> Directors { get; set; }

        // Genre Data
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public string CreateGenreName { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        [StringLength(150)]
        public string GenreName { get; set; }

        // Photos Data
        public string PhotoURL { get; set; }
        public bool IsMainPhoto { get; set; }
        public string DescriptionPhoto { get; set; }
        public List<Photo> Photos { get; set; }

        public double ListingMovieTotalPrice { get; set; }

       
        public int AddToCartTotalCounter { get; set; }


 
        public IEnumerable<Movie> TopPopularMovies { get; set; }
        public IEnumerable<Movie> TopPopularMoviesByBestSellingDirector { get; set; }
        public Director BestSellingDirector { get; set; }
        public IEnumerable<Movie> AllMovies { get; set; }
        public IEnumerable<Movie> AllMoviesFromListingMovieByLoggedInUser { get; set; }
    }
}
