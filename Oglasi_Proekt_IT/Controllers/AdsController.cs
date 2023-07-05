using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oglasi_Proekt_IT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Oglasi_Proekt_IT.Controllers
{
    public class AdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [AllowAnonymous]
        public ActionResult Home()
        {
            return View();
        }

        // GET: Ads
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Ads.ToList());
        }


        // GET: Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            var currUser = User.Identity.Name;
            List<string> viewsList = ad.UserViews.Split(' ').ToList();
            if (!viewsList.Contains(currUser))
            {
                ad.UserViews += " " + currUser;
                ad.ViewCounter++;
                db.SaveChanges();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDnum,Username,Email,Phone,Viber,Location,Title,Description,Price,ImageURL,ViewCounter")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                ad.Location = ad.Location.ToString();
                ad.Username = User.Identity.Name;
                ad.UserViews = "";
                ad.ViewCounter = 0;
                db.Ads.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(ad);
        }


        public ActionResult CreatedAds()
        {
            var currUser = User.Identity.Name;
            var createdAds = db.Ads.Where(ad => ad.Username == currUser);
            return View(createdAds.ToList());

        }

        // GET: Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDnum,Username,Email,Phone,Viber,Location,Title,Description,Price,ImageURL,ViewCounter")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        

        
        public ActionResult Delete(int id)
        {
            Ad ad = db.Ads.Find(id);
            db.Ads.Remove(ad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        
    }
}
