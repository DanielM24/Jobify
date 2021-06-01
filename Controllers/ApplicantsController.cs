using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jobify.Models;

namespace Jobify.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicantsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Applicants
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.RecruiterUser))
                return View("ReadOnlyList", _context.Applicants.ToList());
            return View("List", _context.Applicants.ToList());
        }



        // GET: Applicants/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = _context.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create( Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Applicants.Add(applicant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = _context.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit([Bind(Include = "ApplicantId,FirstName,LastName,Email")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(applicant).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = _context.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult DeleteConfirmed(byte id)
        {
            Applicant applicant = _context.Applicants.Find(id);
            _context.Applicants.Remove(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
