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
    public class NotificationsController : Controller
    {
        private SaMEntities db = new SaMEntities();

        // GET: Notifications
        public ActionResult Index()
        {
            var notifications = db.Notifications.Include(n => n.Tasks);
            return View(notifications.ToList());
        }

        // GET: Notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifications notifications = db.Notifications.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            return View(notifications);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaskId,SentAt,Type,Message")] Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", notifications.TaskId);
            return View(notifications);
        }

        // GET: Notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifications notifications = db.Notifications.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", notifications.TaskId);
            return View(notifications);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaskId,SentAt,Type,Message")] Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskId = new SelectList(db.Tasks, "Id", "Name", notifications.TaskId);
            return View(notifications);
        }

        // GET: Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifications notifications = db.Notifications.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            return View(notifications);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notifications notifications = db.Notifications.Find(id);
            db.Notifications.Remove(notifications);
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
