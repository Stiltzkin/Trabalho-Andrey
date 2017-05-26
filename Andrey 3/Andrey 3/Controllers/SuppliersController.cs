using Andrey_3.Contexts;
using Andrey_3.Views.Categories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Andrey_3.Controllers
{
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(c => c.Name));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supplier).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        // GET: Testes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Supplier fabricante = context.Suppliers.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Supplier supplier = context.Suppliers.Find(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " +
            supplier.Name.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }



    }
}