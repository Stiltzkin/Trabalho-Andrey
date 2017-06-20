using Andrey_2.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Andrey_2.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Produtos
        public ActionResult Index()
        {
            return View(context.Produtos.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.
            OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.
            OrderBy(b => b.Nome), "FabricanteId", "Nome");
            return View();
        }

    }
}