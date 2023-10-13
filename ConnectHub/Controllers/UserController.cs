using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectHub.Models;

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
                var currentDog = repo.GetUser(userToUpdate.UserID);
                userToUpdate.ProfilePicture = currentDog.ProfilePicture;
            }
            repo.UpdateUser(userToUpdate);
            return RedirectToAction("Index");
        }

        public IActionResult InsertUser()
        {
            var user = repo.AssignCategory();
            return View(user);
        }

        [HttpPost]
        public IActionResult InsertUserToDatabase(User user, IFormFile picture)
        {

            if (picture != null && picture.Length > 0)
            {
                user.ProfilePicture = new byte[picture.Length];
                picture.OpenReadStream().Read(user.ProfilePicture, 0, (int)picture.Length);
            }
            else
            {
                var currentDog = repo.GetUser(user.UserID);
                user.ProfilePicture = currentDog.ProfilePicture;
            }
            repo.InsertUser(user);
            return RedirectToAction("Index");

            //repo.InsertUser(user);

            //return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(User user)
        {
            repo.DeleteUser(user);
            return RedirectToAction("Index");
        }
    }
}

