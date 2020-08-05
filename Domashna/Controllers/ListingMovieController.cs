using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Models;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Domashna.Controllers
{
    public class ListingMovieController : Controller
    {
        private readonly IListingMovieService _listingMovieService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMovieService _movieService;
        private readonly IRentingMovieService _rentingMovieService;
        private readonly ILogger<ListingMovieController> _logger;
        public ListingMovieController(
            IListingMovieService listingMovieService,
            IHttpContextAccessor httpContextAccessor,
            IMovieService movieService,
            IRentingMovieService rentingMovieService,
            ILogger<ListingMovieController> logger)
        {
             _listingMovieService = listingMovieService;
            _httpContextAccessor = httpContextAccessor;
            _movieService = movieService;
            _rentingMovieService = rentingMovieService;
            _logger = logger;
        }
        public IActionResult Index()
        {

                List<Movie> AllMovieListFromListingMovieByLoggedInUser = new List<Movie>();

                var TotalPriceCount = 0.0;

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var listingMovies = _listingMovieService.GetAllListingMovieByUserId(userId);


                foreach (var item in listingMovies)
                {

                    var movie = _movieService.GetMovieById(item.MovieId);
                    if (movie != null)
                    {
                        AllMovieListFromListingMovieByLoggedInUser.Add(movie);
                        _logger.LogInformation(LoggerMessageDisplay.ListMovieListed);
                    }
                    else
                    {
                    _logger.LogInformation(LoggerMessageDisplay.NoListedMovieInDB);
                    }

                }

                TotalPriceCount = Math.Round(AllMovieListFromListingMovieByLoggedInUser.Sum(x => x.Price), 2);

                var movieViewModel = new MovieViewModel();

                movieViewModel.AllMoviesFromListingMovieByLoggedInUser = AllMovieListFromListingMovieByLoggedInUser;

                movieViewModel.ListingMovieTotalPrice = TotalPriceCount;

                return View(movieViewModel);
       
        }
        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.NoListedsMovieFound);
            }
            return View(movie);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getMovie = _movieService.GetMovieById(Id);

            if(getMovie != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.ListedMovieFoundDisplayDetails);
            }

            _listingMovieService.DeleteByMovieId(Id);

            return new JsonResult(new { data = getMovie, url = Url.Action("Index", "ListingMovie") });
        }
        public JsonResult AddToCartFromListingMovie(List<string> movieIds)
        {
            List<string> movieIds_temp = movieIds;
            foreach (var movie in movieIds_temp)
            {
                var getMovie = _movieService.GetMovieById(int.Parse(movie));
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var movieId = getMovie.Id;
                var rentingMovie = new RentingMovie
                {
                    UserId = userId,
                    MovieId = movieId,
                    Price = getMovie.Price,
                    DateAdded = DateTime.Now
                };
                _rentingMovieService.Add(rentingMovie);
            }
            foreach (var selectedItem in movieIds)
            {
                _listingMovieService.DeleteByMovieId(int.Parse(selectedItem));
            }
            return new JsonResult(new { data = "" });
        }
       
    }
}