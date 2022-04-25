using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using finalProject.Models;

namespace finalProject.Controllers
{
    public class ItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Items
        public ActionResult Index()
        {
            var model = new FrontPageViewModel();
            model.Categories = db.Categories.Include(i => i.Items).ToList();
            return View(model);
        }

        // GET: Items/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "id", "name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                item.itemId = Guid.NewGuid();
                if (fileBase != null)
                {
                    MemoryStream target = new MemoryStream();
                    fileBase.InputStream.CopyTo(target);
                    item.image = target.ToArray();
                }

                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categories = new SelectList(db.Categories, "id", "name", item.categoryId);
            return View();
        }

        // GET: Items/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            var model = new ItemViewModel();
            model.Item = item;
            ViewBag.categories = new SelectList(db.Categories, "id", "name", model.Item.categoryId);
            return View(model);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item, HttpPostedFileBase fileBase)
        {
            if (ModelState.IsValid)
            {
                if (fileBase != null)
                {
                    MemoryStream target = new MemoryStream();
                    fileBase.InputStream.CopyTo(target);
                    item.image = target.ToArray();
                }

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Items");
            }

            ViewBag.categories = new SelectList(db.Categories, "id", "name");
            var model = new ItemViewModel();
            model.Item = item;
            model.FileBase = fileBase;
            return View(model);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.categories = new SelectList(db.Categories, "id", "name", item.categoryId);
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisplayCategory(Guid id)
        {
            TempData["selectedCategoryId"] = id;
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
