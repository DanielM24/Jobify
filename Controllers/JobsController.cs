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
    public class JobsController : Controller
    {
        private ApplicationDbContext _context;

        public JobsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = _context.Jobs.Include(j => j.Company);
            if (User.IsInRole(RoleName.RecruiterUser))
                return View("List", jobs.ToList());
            return View("ReadOnlyList", jobs.ToList());
        }


        // GET: Jobs/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = _context.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult Create([Bind(Include = "JobId,JobName,JobDescription,DurationInMonths,Salary,City,IsRemote,CompanyId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = _context.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult Edit([Bind(Include = "JobId,JobName,JobDescription,DurationInMonths,Salary,City,IsRemote,CompanyId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(job).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(_context.Companies, "CompanyId", "CompanyName", job.CompanyId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = _context.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.RecruiterUser)]
        public ActionResult DeleteConfirmed(byte id)
        {
            Job job = _context.Jobs.Find(id);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
