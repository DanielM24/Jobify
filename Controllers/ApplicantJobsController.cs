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
    public class ApplicantJobsController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicantJobsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ApplicantJobs
        public ActionResult Index()
        {
            var applicantJob = _context.ApplicantJob.Include(a => a.Applicant).Include(a => a.Job);
            return View(applicantJob.ToList());
        }

        // GET: ApplicantJobs/Details/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJob applicantJob = _context.ApplicantJob.Find(id);
            if (applicantJob == null)
            {
                return HttpNotFound();
            }
            return View(applicantJob);
        }

        // GET: ApplicantJobs/Create
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create()
        {
            ViewBag.ApplicantId = new SelectList(_context.Applicants, "ApplicantId", "FirstName");
            ViewBag.JobId = new SelectList(_context.Jobs, "JobId", "JobName");
            return View();
        }

        // POST: ApplicantJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Create([Bind(Include = "ApplicantId,JobId")] ApplicantJob applicantJob)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicantJob.Add(applicantJob);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantJob.ApplicantId);
            ViewBag.JobId = new SelectList(_context.Jobs, "JobId", "JobName", applicantJob.JobId);
            return View(applicantJob);
        }

        // GET: ApplicantJobs/Edit/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJob applicantJob = _context.ApplicantJob.Find(id);
            if (applicantJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantJob.ApplicantId);
            ViewBag.JobId = new SelectList(_context.Jobs, "JobId", "JobName", applicantJob.JobId);
            return View(applicantJob);
        }

        // POST: ApplicantJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Edit([Bind(Include = "ApplicantId,JobId")] ApplicantJob applicantJob)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(applicantJob).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantId = new SelectList(_context.Applicants, "ApplicantId", "FirstName", applicantJob.ApplicantId);
            ViewBag.JobId = new SelectList(_context.Jobs, "JobId", "JobName", applicantJob.JobId);
            return View(applicantJob);
        }

        // GET: ApplicantJobs/Delete/5
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJob applicantJob = _context.ApplicantJob.Find(id);
            if (applicantJob == null)
            {
                return HttpNotFound();
            }
            return View(applicantJob);
        }

        // POST: ApplicantJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ApplicantUser)]
        public ActionResult DeleteConfirmed(byte id)
        {
            ApplicantJob applicantJob = _context.ApplicantJob.Find(id);
            _context.ApplicantJob.Remove(applicantJob);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
