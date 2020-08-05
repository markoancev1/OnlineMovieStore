using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Repositories.Repositories.Interfaces;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Domashna.Controllers
{
    [Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly ILogger<GenreController> _logger;

        public GenreController(IGenreService genreService, ILogger<GenreController> logger)
        {

            _genreService = genreService;
            _logger = logger;

        }  

        public IActionResult Index()
        {

                var genreList = _genreService.GetAllGenres();

                if (genreList != null)
                {
                _logger.LogInformation(LoggerMessageDisplay.GenresListed);
                }
                else
                {
                    _logger.LogInformation(LoggerMessageDisplay.NoGenresInDB);
                }

                return View(genreList);
 
        }

        [HttpGet]

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Add(genre);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreNotCreatedModelStateInvalid);
            }
            return View();
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var genre = _genreService.GetGenreById(id);
            if (genre == null)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreCreatedNotFound);
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]

        public IActionResult Edit(int id, Genre genre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _genreService.Edit(genre);

                }
                catch (Exception ex)
                {
                    _logger.LogInformation(LoggerMessageDisplay.GenreEditErrorModelStateInvalid);
                    throw;
                }
                RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        public IActionResult Details(int id)
        {
            var genre = _genreService.GetGenreById(id);

            if (genre == null)
            {
                _logger.LogInformation(LoggerMessageDisplay.NoGenreFound);
                return NotFound();
            }

            return View(genre);
        }

        public IActionResult Delete(int id)
        {
            var genre = _genreService.GetGenreById(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]

        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _genreService.Delete(Id);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreDeleteErrorModelStateInvalid);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]

        public JsonResult CreateGenreAJAX(string name)
        {
            var genre = new Genre();
            if (name != "" || name != null)
            {
                genre.Name = name;
                _genreService.Add(genre);
            }
            return Json(genre);
        }
    }
}