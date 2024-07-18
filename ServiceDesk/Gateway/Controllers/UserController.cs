using Gateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult CustomerIndex()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AdministratorIndex()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [Authorize(Roles = "Serviceman")]
        public IActionResult ServicemanIndex()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userService.UpdateUserAsync(user);
                if (result.Succeeded)
                {
                }
                ModelState.AddModelError("", "Failed to update user");
            }
            return RedirectToAction("AdministratorIndex");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                var result = await _userService.DeleteUserAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to delete user");
                }
            }
            return RedirectToAction("AdministratorIndex");
        }

        public async Task<IActionResult> ChangeRole(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = new List<string> { "Administrator", "Customer", "Serviceman" };
            var userRole = await _userService.GetUserByIdAsync(user.Id); // Replace with actual logic to get user's role
            var model = new ChangeRoleViewModel
            {
                User = user,
                Roles = roles,
                SelectedRole = userRole?.ToString()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByIdAsync(model.User.Id);
                var result = await _userService.UpdateUserRoleAsync(user, model.SelectedRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("AdministratorIndex");
                }
                ModelState.AddModelError("", "Failed to change role");
            }
            return View("AdministratorIndex", model);
        }
    }
}




