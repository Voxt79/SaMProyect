using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedProgramming.Data;
///genere los controllers de las tablas de la base de datos,falta cambiarlos

namespace AdvancedProgramming.Mvc.Controllers
{
    public class TaskLogsController : Controller
    {
        private SaMEntities db = new SaMEntities();

        // GET: TaskLogs
        public ActionResult Index()
        {
            var taskLogs = db.TaskLogs.Include(t => t.Tasks);
            return View(taskLogs.ToList());
        }

        // GET: TaskLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskLogs taskLogs = db.TaskLogs.Find(id);
            if (taskLogs == null)
            {
                return HttpNotFound();
            }
            return View(taskLogs);
        }

        // GET: TaskLogs/Create
        public ActionResult Create()
        {
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name");
            return View();
        }

        // POST: TaskLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaskId,StartTime,EndTime,Success,ErrorMessage")] TaskLogs taskLogs)
        {
            if (ModelState.IsValid)
            {
                db.TaskLogs.Add(taskLogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", taskLogs.TaskId);
            return View(taskLogs);
        }

        // GET: TaskLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskLogs taskLogs = db.TaskLogs.Find(id);
            if (taskLogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", taskLogs.TaskId);
            return View(taskLogs);
        }

        // POST: TaskLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaskId,StartTime,EndTime,Success,ErrorMessage")] TaskLogs taskLogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskLogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", taskLogs.TaskId);
            return View(taskLogs);
        }

        // GET: TaskLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskLogs taskLogs = db.TaskLogs.Find(id);
            if (taskLogs == null)
            {
                return HttpNotFound();
            }
            return View(taskLogs);
        }

        // POST: TaskLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskLogs taskLogs = db.TaskLogs.Find(id);
            db.TaskLogs.Remove(taskLogs);
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
