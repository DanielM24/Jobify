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
    public class ApplicantDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicantDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: ApplicantDetails
        public ActionResult Index()
        {
            var applicantDetails = _context.ApplicantDetails.Include(a => a.Applicant);
            return View(applicantDetails.ToList());
        }

        // GET: ApplicantDetails/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetails applicantDetails = _context.ApplicantDetails.Find(id);
            if (applicantDetails == null)
            {
                return HttpNotFound();
            }
            return View(applicantDetails);
        }

        // GET: ApplicantDetails/Create
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create()
        {
            ViewBag.ApplicantDetailsId = new SelectList(_context.Applicants, "ApplicantId", "FirstName");
            return View();
        }

        // POST: ApplicantDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create([Bind(Include = "ApplicantDetailsId,PhoneNumber,Age,Bio,Experience,Education,Projects,Languages")] ApplicantDetails applicantDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicantDetails.Add(applicantDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantDetailsId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantDetails.ApplicantDetailsId);
            return View(applicantDetails);
        }

        // GET: ApplicantDetails/Edit/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetails applicantDetails = _context.ApplicantDetails.Find(id);
            if (applicantDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantDetailsId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantDetails.ApplicantDetailsId);
            return View(applicantDetails);
        }

        // POST: ApplicantDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit([Bind(Include = "ApplicantDetailsId,PhoneNumber,Age,Bio,Experience,Education,Projects,Languages")] ApplicantDetails applicantDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(applicantDetails).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantDetailsId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantDetails.ApplicantDetailsId);
            return View(applicantDetails);
        }

        // GET: ApplicantDetails/Delete/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantDetails applicantDetails = _context.ApplicantDetails.Find(id);
            if (applicantDetails == null)
            {
                return HttpNotFound();
            }
            return View(applicantDetails);
        }

        // POST: ApplicantDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult DeleteConfirmed(byte id)
        {
            ApplicantDetails applicantDetails = _context.ApplicantDetails.Find(id);
            _context.ApplicantDetails.Remove(applicantDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
