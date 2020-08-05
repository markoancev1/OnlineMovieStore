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
    public class RentingMovieController : Controller
    {
       
        private readonly IMovieService _movieService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRentingMovieService _rentingMovieService;
        private readonly ILogger<RentingMovieController> _logger;

        public RentingMovieController(
            IMovieService movieService,
            IHttpContextAccessor httpContextAccessor,
            IRentingMovieService rentingMovieService,
            ILogger<RentingMovieController> logger)
        {
            _movieService = movieService;
            _httpContextAccessor = httpContextAccessor;
            _rentingMovieService = rentingMovieService;
            _logger = logger;
        }

        public ActionResult Index()
        {
            
            List<Movie> AllMovieListFromCartByLoggedInUser = new List<Movie>();
            var TotalPriceCount = 0.0;
            var TotalShipping = 0.0;
            var NotificationCounter = 0;

            
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var itemsInCart = _rentingMovieService.GetAllItemsInCartByUserId(userId);

            foreach (var item in itemsInCart)
            {
                var movie = _movieService.GetMovieById(item.MovieId);
                if (movie != null)
                {
                    AllMovieListFromCartByLoggedInUser.Add(movie);
                    _logger.LogInformation(LoggerMessageDisplay.RentMovieListed);
                }
                else
                {
                    _logger.LogInformation(LoggerMessageDisplay.NoRentedMovieInDB);
                }
            }

            TotalPriceCount = TotalShipping + Math.Round(AllMovieListFromCartByLoggedInUser.Sum(x => x.Price), 2);
            NotificationCounter = _rentingMovieService.GetAllItemsInCart().Count();

            var rentingMovieViewModel = new RentingMovieViewModel()
            {
                SubTotal = Math.Round(AllMovieListFromCartByLoggedInUser.Sum(x => x.Price), 2),
                ShippingTotal = 0.0,
                TotalPrice = TotalPriceCount,
                AllMoviesAddedToCartByLoggedInUser = AllMovieListFromCartByLoggedInUser,
                AddToCartTotalCounter = NotificationCounter
            };

            ViewData["Counter"] = NotificationCounter;

            return View(rentingMovieViewModel);
        }

        public JsonResult AddToRentingMovie(int id)
        {
          
            var getMovieById = _movieService.GetMovieById(id);
          
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            var movieId = getMovieById.Id;
            var directorId = getMovieById.DirectorID;
            var genreId = getMovieById.GenreID;

          
            var rentingMovie = new RentingMovie
            {
                UserId = userId,
                MovieId = movieId,
                Price = getMovieById.Price,
                DateAdded = DateTime.Now
            };

       
            _rentingMovieService.Add(rentingMovie);

            return new JsonResult(new { data = rentingMovie });
        }


        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getMovie = _movieService.GetMovieById(Id);

            if(getMovie != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.RentedMovieDeleted);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoRentedsMovieFound);
            }

            _rentingMovieService.DeleteByMovieId(Id);
            
            return new JsonResult(new { data = getMovie, url = Url.Action("Index", "RentingMovie") });
        }
    }
}