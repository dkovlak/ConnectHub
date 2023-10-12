using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectHub.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConnectHub.Controllers
{
    public class UserController : Controller
    {

        private IUserRepository repo;
        public UserController(IUserRepository repo)
        {

            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = repo.GetAllUsers();

            return View(users);
        }

        
        public IActionResult ViewUser(int id)
        {
            var user = repo.GetUser(id);
            return View(user);
        }

        //[HttpGet]
        //[Authorize(Roles ="User")]
        //public IActionResult Profile()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Profile(UserViewModel model)
        //{
        //    return View();
        //}

        public IActionResult UpdateUser(int id)
        {
            User user = repo.GetUser(id);

            if(user == null)
            {
                return View("UserNotFound");
            }

            return View(user);
        }

        //public IActionResult UpdateUserToDatabase(User user)
        //{
        //    repo.UpdateUser(user);

        //    return RedirectToAction("ViewUser", new { id = user.UserID });


        //}

        [HttpPost]
        public IActionResult UpdateUserToDatabase(User userToUpdate, IFormFile picture)
        {
            if (picture != null && picture.Length > 0)
            {
                userToUpdate.ProfilePicture = new byte[picture.Length];
                picture.OpenReadStream().Read(userToUpdate.ProfilePicture, 0, (int)picture.Length);
            }
            else
            {
                var currentUser = repo.GetUser(userToUpdate.UserID);
                userToUpdate.ProfilePicture = currentUser.ProfilePicture;
            }
            repo.UpdateUser(userToUpdate);
            return RedirectToAction("Index");
        }

        public IActionResult InsertUser()
        {
            var user = repo.AssignCategory();
            return View(user);
        }

        public IActionResult InsertUserToDatabase(User user)
        {
            repo.InsertUser(user);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult AddUserToDatabase(User userToAdd, IFormFile picture)
        //{
        //    if (picture != null && picture.Length > 0)
        //    {
        //        userToAdd.ProfilePicture = new byte[picture.Length];
        //        picture.OpenReadStream().Read(userToAdd.ProfilePicture, 0, (int)picture.Length);
        //    }
        //    repo.InsertUser(userToAdd);
        //    return RedirectToAction("Index"/*, new { id = dogToAdd.DogID }*/);
        //}

        public IActionResult DeleteUser(User user)
        {
            repo.DeleteUser(user);
            return RedirectToAction("Index");
        }
    }
}

