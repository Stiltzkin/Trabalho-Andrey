using Andrey_8.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Andrey_8.Models;
using System.Net;

namespace Andrey_8.Controllers
{
    public class CadastrosController : Controller
    {
        private EFContext context = new EFContext();


        public ActionResult Index()
        {
            var cadastros = context.Cadastros.Include(c => c.Cobertura).
            Include(f => f.Cliente).OrderBy(n => n.NumeroCadastro);
            return View(cadastros);
        }

        public ActionResult Create()
        {
            ViewBag.CoberturaId = new SelectList(context.Coberturas.
            OrderBy(b => b.Nome), "CoberturaId", "Nome");
            ViewBag.ClienteId = new SelectList(context.Clientes.
            OrderBy(b => b.Nome), "ClienteId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cadastro cadastro)
        {
            try
            {
                context.Cadastros.Add(cadastro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cadastro);
            }
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Cadastro cadastro = context.Cadastros.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoberturaId = new SelectList(context.Coberturas.
            OrderBy(b => b.Nome), "CoberturaId", "Nome", cadastro.
            CoberturaId);
            ViewBag.ClienteId = new SelectList(context.Clientes.
            OrderBy(b => b.Nome), "ClienteId", "Nome", cadastro.
            ClienteId);
            return View(cadastro);
        }
        [HttpPost]
        public ActionResult Edit(Cadastro cadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(cadastro).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cadastro);
            }
            catch
            {
                return View(cadastro);
            }
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }

            Cadastro cadastro = context.Cadastros.Where(p => p.CadastroId ==
            id).Include(c => c.Cobertura).Include(f => f.Cliente).
            First();
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Cadastro cadastro = context.Cadastros.Where(p => p.CadastroId ==
            id).Include(c => c.Cobertura).Include(f => f.Cliente).
            First();
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cadastro cadastro = context.Cadastros.Find(id);
                context.Cadastros.Remove(cadastro);
                context.SaveChanges();
                TempData["Message"] = "Produto " + cadastro.NumeroCadastro.ToString() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}