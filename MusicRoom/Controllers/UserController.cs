using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MusicRoom.Models;

namespace Music.Controllers
{
    public class UserController : Controller
    {

        private MusicRoomContext db;
        //Create instance of the context
        public UserController()
        {
            db = new MusicRoomContext();
        }

        // GET: User
        //Get requested user info from DB by id
        [Route("User/UserInfo/{id}")]
        [Route("User/UserInfo")]
        public ActionResult UserInfo(int? Id)
        {
            //Check if user in DB    
            bool exists = db.Users.Where(u => u.Id == Id).Any();
            //If found, return view
            if (exists)
            {
                //Eager loading
                User model = db.Users.Where(u => u.Id == Id).Include(i => i.Instruments).Include(b => b.Bands).FirstOrDefault();
                return View(model);
            }

            else
            //If not found, redirect to client info page
            {
                int clientId = db.Users.Where(x => x.Username == User.Identity.Name).FirstOrDefault().Id;
                return RedirectToRoute(new
                {
                    controller = "User",
                    action = "UserInfo",
                    Id = clientId,
                });

            }
        }


        //To start the search page with no results
        public ActionResult ListUsers()
        {
            //Pass whole bands data to view
            var emptyModel = db.Users.AsEnumerable();
            return View(emptyModel);
        }

        //QUICK SEARCH FORM ON POST
        [HttpGet]
        public ActionResult Search(string searchString)
        {
            //List to hold substrings of searchString (Divided by " ")
            List<string> searchSubstrings = searchString.Split(' ').ToList();
            var model = new List<User>();
            //Foreach substring add containing users to model
            foreach (string s in searchSubstrings)
            {
                //Select where any string-property contains substring s
                var relevantUsers = db.Users.Where(b => b.Username.Contains(s) || b.Instruments.Any(i => i.Name.Contains(s)) || b.Genres.Any(g => g.Name.Contains(s)) || b.Bands.Any(band => band.BandName.Contains(s)) || b.FullName.Contains(s));
                //If is first s ( <=> model is empty), then just add all relevant users
                if (!model.Any()) model.AddRange(relevantUsers);
                //If not, remove from model any band that doesn't appear in relevantBands
                else
                {
                    foreach (User u in relevantUsers)
                    {
                        model.RemoveAll(x => !relevantUsers.Any(user => user.Id == x.Id));
                    }

                }
            }

            //Pass updated model to view
            return View("ListUsers", model);
        }



        //Route for the new user form page
        [Route("User/NewUser")]
        public ActionResult NewUser()
        {
            db = new MusicRoomContext();
            //Re-check that used is not in DB
            bool exists = db.Users.Where(u => u.Username == User.Identity.Name).Any();
            //If exists, redirect to client info page
            if (exists)
            {
                int clientId = db.Users.Where(x => x.Username == User.Identity.Name).FirstOrDefault().Id;
                return RedirectToRoute(new
                {
                    controller = "User",
                    action = "UserInfo",
                    Id = clientId,
                });
            }
            //If doesn't exist, create new user
            else
            {
                User user = new User { Username = User.Identity.Name };
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("UserInfo", "User");
                }

                return View();
            }
        }

    }
}