using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domashna.Data.Entities;
using Domashna.Logger;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Domashna.Controllers
{
    [Authorize(Roles = "admin")]
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;
        private readonly ILogger<DirectorController> _logger;

        public DirectorController(IDirectorService directorService, ILogger<DirectorController> logger)
        {

            _directorService = directorService;
            _logger = logger;

        }
        public IActionResult Index()
        {
            var directorList = _directorService.GetAllDirectors();
            if (directorList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorsListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoDirectorsInDB);
            }
            return View(directorList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _directorService.Add(director);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorNotCreatedModelStateInvalid);
            }
            return View();
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost]

        public IActionResult Edit(int id, Director director)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _directorService.Edit(director);

                }
                catch (Exception ex)
                {
                    _logger.LogInformation(LoggerMessageDisplay.DirectorEditErrorModelStateInvalid, ex);
                    throw;
                }
                RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        public IActionResult Details(int id)
        {
            var director = _directorService.GetDirectorById(id);

            if (director == null)
            {
                _logger.LogInformation(LoggerMessageDisplay.NoDirectorFound);
                return NotFound();
            }

            return View(director);
        }

        public IActionResult Delete(int id)
        {
            var director = _directorService.GetDirectorById(id);

            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        [HttpPost]

        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                _directorService.Delete(Id);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.DirectorDeleteErrorModelStateInvalid);
            }

            return RedirectToAction(nameof(Index));

        }

        public JsonResult CreateDirectorAJAX(string name, string country)
        {
            var director = new Director();
            if (name != "" || name != null)
            {
                director.Name = name;
                director.Country = country;
                _directorService.Add(director);
            }
            return Json(director);
        }
    }
}