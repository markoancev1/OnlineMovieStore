using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domashna.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Views.Shared
{
    public class NotificationsModel : PageModel
    {
        private readonly IRentingMovieService _rentingMovieService;

        public NotificationsModel(IRentingMovieService rentingMovieService)
        {
            _rentingMovieService = rentingMovieService;
        }

        public void OnGet()
        {
            var notificationCounters = _rentingMovieService.GetAllItemsInCart().Count();

            ViewData["Counter"] = notificationCounters;
        }
    }
}