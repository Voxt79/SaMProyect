using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedProgramming.Business;
using AdvancedProgramming.Data;
///Este es funcional los muestra
namespace AdvancedProgramming.Mvc.Controllers
{
    public class TasksController : Controller
    {
        private readonly TasksBusiness tasksBusiness;
        public TasksController()
        {
            tasksBusiness = new TasksBusiness();

        }
        // GET: Tasks
        public ActionResult Index()
        {
        var Tasks = tasksBusiness.Get(id: null);
            return View(Tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tasks tasks = tasksBusiness.Get(id).FirstOrDefault();
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(Enumerable.Empty<object>(), "Id", "FullName");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Name,Description,Priority,Status,CreatedAt,ScheduledAt,FinishedAt")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                tasksBusiness.Save(tasks.Id, tasks);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = ViewBag.UserId = new SelectList(Enumerable.Empty<object>(), "Id", "FullName", tasks.UserId);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = tasksBusiness.Get(id).FirstOrDefault();
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = ViewBag.UserId = new SelectList(Enumerable.Empty<object>(), "Id", "FullName", tasks.UserId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Name,Description,Priority,Status,CreatedAt,ScheduledAt,FinishedAt")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                   tasksBusiness .Save(tasks.Id, tasks);
                return RedirectToAction("Index");
             
            }
            ViewBag.UserId = ViewBag.UserId = new SelectList(Enumerable.Empty<object>(), "Id", "FullName", tasks.UserId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = tasksBusiness.Get(id).FirstOrDefault();
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = tasksBusiness.Get(id).FirstOrDefault();
            tasksBusiness.Save(tasks.Id, tasks);
            return RedirectToAction("Index");
        }
    }
}
