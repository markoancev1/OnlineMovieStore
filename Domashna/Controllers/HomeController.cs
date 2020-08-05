using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domashna.Models;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Domashna.Data.Entities;
using System.Security.Claims;

namespace Domashna.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;
        private readonly IListingMovieService _listingMovieService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRentingMovieService _rentingMovieService;
        public HomeController(
            IMovieService movieService,
            IDirectorService directorService,
            IListingMovieService listingMovieService,
            IHttpContextAccessor httpContextAccessor,
            IRentingMovieService rentingMovieService
            )
        {
            _movieService = movieService;
            _directorService = directorService;
            _listingMovieService = listingMovieService;
            _httpContextAccessor = httpContextAccessor;
            _rentingMovieService = rentingMovieService;
        }
        public IActionResult Index()
        {
            var GetTopMovies = _movieService.GetTopPopularMovie();
            var GetPopularDirector = _directorService.GetDirectorByPopularity();
            var GetTopPopularMoviesByBestSellingDirector = _movieService.GetTopPopularMoviesByBestSellingDirector(GetPopularDirector.Id);
            var GetAllMovies = _movieService.GetAllMovies();
            var notificationCounters = _rentingMovieService.GetAllItemsInCart().Count();
            var movieViewModel = new MovieViewModel
            {
                TopPopularMovies = GetTopMovies,
                TopPopularMoviesByBestSellingDirector = GetTopPopularMoviesByBestSellingDirector,
                BestSellingDirector = GetPopularDirector,
                AllMovies = GetAllMovies,
                AddToCartTotalCounter = notificationCounters
            };
            ViewData["Counter"] = notificationCounters;
            return View(movieViewModel);
        }
        [HttpPost]
        public IActionResult RefreshPartialViewNotification()
        {
            var notificationCounters = _rentingMovieService.GetAllItemsInCart().Count();
            ViewData["Counter"] = notificationCounters;
            return PartialView("Notification");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public int AddToCartNotificationsCounterTest()
        {
            var notificationCounters = _rentingMovieService.GetAllItemsInCart().Count();
            return notificationCounters;
        }
        [HttpPost]
        public JsonResult AddToListingMovie(int id)
        {
            var getMovieById = _movieService.GetMovieById(id);
            var CheckIfExistsInListingMovie = _listingMovieService.GetListingMovieByMovieId(id);
            if (CheckIfExistsInListingMovie == null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var movieId = getMovieById.Id;
                var directorId = getMovieById.DirectorID;
                var genreId = getMovieById.GenreID;
                var listingMovie = new ListingMovie
                {
                    UserId = userId,
                    MovieId = movieId,
                    DirectorId = directorId,
                    GenreId = genreId,
                    DateAdded = DateTime.Now
                };
                _listingMovieService.Add(listingMovie);
                return new JsonResult(new { data = listingMovie });
            }
            else
            {
                return new JsonResult(new { data = "" });
            }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
