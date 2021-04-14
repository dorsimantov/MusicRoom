using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicRoom.Models;

namespace MusicRoom.Controllers
{
    public class PurchaseRequestController : Controller
    {
        private MusicRoomContext db;
        // GET: PurchaseRequest
        public ActionResult NewPurchaseRequest()
        {
            return View();
        }


        //CREATE FORM ON POST   
        //Band parameter seeds DB, others to be set for its' properties
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePurchaseRequest(PurchaseRequest request)
        {

            if (ModelState.IsValid)
            {
                using (db = new MusicRoomContext())
                {
                    //set RequestorId to client's Id
                    request.RequestorId = db.Users.FirstOrDefault(u => u.Username == User.Identity.Name).Id;
                    //Add request to context
                    db.PurchaseRequests.Add(request);
                    //Save to DB
                    db.SaveChanges();
                    //Redirect to home
                    return RedirectToAction("Index", "Home");
                }

            }

            //If Model State NOT valid:
            else return View("NewPurchaseRequest", request);
        }
    }
}