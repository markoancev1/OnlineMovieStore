using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domashna.Data.Entities;
using Domashna.Models;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Domashna.Logger;
using Microsoft.AspNetCore.Authorization;

namespace Domashna.Controllers
{
    [Authorize(Roles = "admin, editor")]
    public class MovieController : Controller
    {
        public readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IDirectorService _directorService;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieService movieService,
                               IGenreService genreService,
                               IDirectorService directorService,
                               ILogger<MovieController> logger)
                     
        {
            _movieService = movieService;
            _genreService = genreService;
            _directorService = directorService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var bookList = _movieService.GetAllMovies();
            if (bookList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.MoviesListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoMoviesInDB);
            }
            return View(bookList);
        }

        public JsonResult FillMoviesDataTable()
        {
            var movielist = _movieService.GetAllMovies();
            return Json(new { data = movielist });
        }

        [Authorize(Roles = "admin")]

        public IActionResult Create()
        {
            var Genres = _genreService.GetAllGenres();
            var Directors = _directorService.GetAllDirectors();

            MovieViewModel movieViewlModel = new MovieViewModel();
            movieViewlModel.Genres = GetSelectListItemsGenres(Genres);
            movieViewlModel.Directors = GetSelectListItemsDirectors(Directors);
            if (Genres != null && Directors != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieCreated);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieCreatedNotFound);
            }
            return View(movieViewlModel);

        }

        private IEnumerable<SelectListItem> GetSelectListItemsGenres(IEnumerable<Genre> genres)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select genre..."
            });
            foreach (var element in genres)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemsDirectors(IEnumerable<Director> directors)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select director..."
            });
            foreach (var element in directors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]

        public IActionResult Create(MovieViewModel movieViewModel)
        {
            var movie = new Movie();
            if (ModelState.IsValid)
            {
                movie.Title = movieViewModel.Title;
                movie.YearOfRelease = movieViewModel.YearOfRelease;
                movie.IMBDScore = movieViewModel.IMBDScore;
                movie.Country = movieViewModel.Country;
                movie.Language = movieViewModel.Language;
                movie.Price = movieViewModel.Price;
                movie.Description = movieViewModel.Description;
                movie.PhotoURL = movieViewModel.PhotoURL;
                movie.SoldItems = movieViewModel.SoldItems;
                movie.GenreID = movieViewModel.GenreID;
                movie.GenreName = movieViewModel.GenreName;
                movie.DirectorID = movieViewModel.DirectorID;
                movie.DirectorName = movieViewModel.DirectorName;


                _movieService.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieNotCreatedModelStateInvalid);
            }
            return View();
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieEdited);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieEditNotFound);
            }
            return View(movie);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.Edit(movie);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(LoggerMessageDisplay.MovieEditErrorModelStateInvalid, ex);
                }
                RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);

            if (movie == null)
            {
                _logger.LogInformation(LoggerMessageDisplay.NoMovieFound);
                return NotFound();
            }

            return View(movie);
        }

        [Authorize(Roles = "admin")]

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);

            if (movie != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieFoundDisplayDetails);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoMoviesInDB);
            }

            return View(movie);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]

        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _movieService.Delete(Id);
                _logger.LogInformation(LoggerMessageDisplay.MovieDeleted);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.MovieDeleteErrorModelStateInvalid);
            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Internal server error");
                
            }
        }
    }
}