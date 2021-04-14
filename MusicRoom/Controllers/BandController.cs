using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRoom.Models;
using MusicRoom.ViewModels;
using System.Data.Entity;

namespace MusicRoom.Controllers
{
    public class BandController : Controller
    {
        private MusicRoomContext db;
        // GET: Band
        [Route("Band/BandInfo/{id}")]
        [Route("Band/BandInfo")]
        public ActionResult BandInfo(int? Id)
        {
            db = new MusicRoomContext();

            //Get from DB band with given Id
            Band model = db.Bands.Where(b => b.Id == Id).Include(b => b.Genres).Include(b => b.Instruments).Include(b => b.Users).FirstOrDefault();
            //If found
            if (model != null)
            {
                return View(model);
            }
            //If band with given Id not found, redirect to error page
            else return RedirectToAction("Error", "Home");
               
        }

        //Routing to the new band form page
        public ActionResult NewBand()
        {
            //SHOULD RETURN VIEW MODEL OF BAND, GENRE, INSTRUMENTS, USERS
            var viewModel = new NewBandViewModel();
            return View(viewModel);
        }

        //To start the search page with no results
        public ActionResult ListBands()
        {
            db = new MusicRoomContext();
            //Pass whole bands data to view
            var emptyModel = db.Bands.AsEnumerable();
            return View(emptyModel);
        }

        //QUICK SEARCH FORM ON POST
        [HttpGet]
        public ActionResult Search(string searchString)
        {
            db = new MusicRoomContext();
            //List to hold substrings of searchString (Divided by " ")
            List<string> searchSubstrings = searchString.Split(' ').ToList();
            var model = new List<Band>();
            //Foreach substring add containing bands to model
            foreach(string s in searchSubstrings)
            {
                //Select where any string-property contains substring s
                var relevantBands = db.Bands.Where(b => b.BandName.Contains(s) || b.Instruments.Any(i => i.Name.Contains(s)) || b.Genres.Any(g => g.Name.Contains(s)) || b.Users.Any(u => u.FullName.Contains(s)));
                //If is first s ( <=> model is empty), then just add all relevant bands
                if (!model.Any()) model.AddRange(relevantBands);
                //If not, remove from model any band that doesn't appear in relevantBands
                else
                {
                    foreach (Band b in relevantBands)
                    {
                        model.RemoveAll(x => !relevantBands.Any(band => band.Id == x.Id));
                    }

                }
            }
   
            //Pass updated model to view
            return View("ListBands", model);
        }

        //CREATE FORM ON POST   
        //Band parameter seeds DB, others to be set for its' properties
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBand(Band Band, IList<Genre> Genres, IList<Instrument> Instruments, IList<User> Users)
        {
           
            //TODO: make sure BandName doesn't exist, maybe in ajax on client
            if (ModelState.IsValid)
            {
                using (db = new MusicRoomContext())
                {
                    //COMMENT OUT AFTER DEVELOPMENT - SQL LOGGER
                    //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //Initialize Band list properties so objects can be added to them
                    Band.Genres = new List<Genre>();
                    Band.Instruments = new List<Instrument>();
                    Band.Users = new List<User>();


                    //Check if values of Users, Instruments and Genres already exist in DB, foreach:
                    //If true - add reference to existing genre
                    //If false - add new genre by value
                    if (Genres != null)
                    {
                        foreach (Genre genre in Genres)
                        {
                            var existsInDB = db.Genres.Any(g => g.Name == genre.Name);

                            if (existsInDB)
                            {
                                Band.Genres.Add(db.Genres.First(g => g.Name == genre.Name));
                            }

                            else Band.Genres.Add(genre);
                        }
                    }

                    if (Instruments != null)
                    {
                        foreach (Instrument instrument in Instruments)
                        {
                            var existsInDB = db.Instruments.Any(i => i.Name == instrument.Name);

                            if (existsInDB)
                            {
                                Band.Instruments.Add(db.Instruments.FirstOrDefault(i => i.Name == instrument.Name));
                            }

                            else Band.Instruments.Add(instrument);
                        }
                    }

                    if (Users != null)
                    {
                        foreach (User user in Users)
                        {
                            var existsInDB = db.Users.Any(u => u.Username == user.Username);

                            if (existsInDB)
                            {
                                Band.Users.Add(db.Users.FirstOrDefault(u => u.Username == user.Username));
                            }

                            else Band.Users.Add(user);
                        }
                    }
                    //Add Band to context
                    db.Bands.Add(Band);
                    //Save to DB
                    db.SaveChanges();
                    //Get Id of the newly-created Band 
                    var newBandId = db.Bands.FirstOrDefault(b => b.BandName == Band.BandName);
                    //Return new band info
                    return RedirectToAction("BandInfo", new { Id = newBandId });
                }

            }

            else
            {
                //If Model State NOT valid:
                //Set form values in the viewModel which is sent back to the client
                var viewModel = new NewBandViewModel
                {
                    Band = Band,
                    Genres = Genres,
                    Instruments = Instruments,
                    Users = Users
                };

                return View("NewBand", viewModel);
            }
        }

    }
}