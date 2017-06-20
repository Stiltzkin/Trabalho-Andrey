using Andrey_8.Contexts;
using Andrey_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Andrey_8.Controllers
{
    
    public class CoberturasController : Controller
    {
        private EFContext context = new EFContext();
        private static IList<Cobertura> coberturas =
        new List<Cobertura>()
        {
            new Cobertura() {
            CoberturaId = 1,
            Nome = "Pesquisa s/ limites"
            }
        };
        public ActionResult Index()
        {
            return View(context.Coberturas.OrderBy(
            c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cobertura cobertura)
        {
            context.Coberturas.Add(cobertura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cobertura).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cobertura);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.Where(f => f.CoberturaId == id).Include("Cadastros.Cobertura").First();
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Cobertura cobertura = context.Coberturas.
            Find(id);
            context.Coberturas.Remove(cobertura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
