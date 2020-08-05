using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domashna.Areas.Identity;
using Domashna.Data;
using Domashna.Data.Entities;
using Domashna.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Domashna.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        private RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<IdentityUser> userManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            RoleManager<IdentityRole> roleManager,
            ILogger<UserController> logger
            )
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            if(users != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.UsersListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoUsersInDB);
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var roles = _roleManager.Roles;
            var userModel = new UserModel();
            userModel.Roles = GetSelectListRoles(roles);
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    EmailConfirmed = true
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.RoleName);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.UserNotCreatedModelStateInvalid);
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles;

            if (user != null)
            {
                var getUserRole = await _userManager.GetRolesAsync(user);
                var userModel = new UserModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = GetSelectListRoles(roles)
                };
                _logger.LogInformation(LoggerMessageDisplay.UserEdited);
                return View(userModel);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password, string RoleName)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var GetUserOldRole = _roleManager.FindByNameAsync(userRoles[0]);

                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, GetUserOldRole.Result.Name);
                        await _userManager.AddToRoleAsync(user, RoleName);
                        return RedirectToAction("Index");
                    }
                    else
                        Errors(result);
                }
            }
            else
                _logger.LogInformation(LoggerMessageDisplay.NoUsersInDB);
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation(LoggerMessageDisplay.UserDeleted);
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogInformation(LoggerMessageDisplay.UserDeletedError);
                    Errors(result);
                }
            }
            else
                _logger.LogInformation(LoggerMessageDisplay.NoUserFound);
            return View("Index", _userManager.Users);
        }



        private IQueryable<SelectListItem> GetSelectListRoles(IQueryable<IdentityRole> roles)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select role..."
            });
            foreach (var element in roles)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id,
                    Text = element.Name
                });
            }
            return selectList.AsQueryable();
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

       
    }
}

