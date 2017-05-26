using Andrey_3.Views.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Andrey_3.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<Category> categories = new List<Category>()
    {
        new Category()
        {
            CategoryId = 1,
            Name = "Notebooks"
        },
        new Category()
        {
            CategoryId = 1,
            Name = "Monitores"
        },
        new Category()
        {
            CategoryId = 1,
            Name = "Impressoras"
        },
        new Category()
        {
            CategoryId = 1,
            Name = "Mouses"
        },
        new Category()
        {
            CategoryId = 1,
            Name = "Desktops"
        }
    };
        // GET: Categories
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            category.CategoryId =
            categories.Select(m => m.CategoryId).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categories.Where(
            m => m.CategoryId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category categoria)
        {
            categories.Remove(categories.Where(
            c => c.CategoryId == categoria.CategoryId)
            .First());
            categories.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categories.Where(
            m => m.CategoryId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(categories.Where(
            m => m.CategoryId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Delete(Category category)
        {
            categories.Remove(categories.Where(
            c => c.CategoryId == category.CategoryId)
            .First());
            return RedirectToAction("Index");
        }
    }
}