using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsContext _db;

        public HomeController(NewsContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var cats = _db.Categories.ToList();
            return View(cats);
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(ContactUS model)
        {
            if (ModelState.IsValid)
            {

                _db.ContactUs.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("ContactUs",model);
        }
        public IActionResult TeamMember()
        {
            return View(_db.TeamMembers.ToList());
        }
        public IActionResult News(int id)
        {
            var c = _db.Categories.Find(id);
            ViewBag.name=c.Name;
            var result = _db.News.Where(n=>n.CategoryID == id).OrderByDescending(x=>x.Date).ToList();
            return View(result);
        }
        public IActionResult DeletNews(int id)
        {
            var c = _db.News.Find(id);
            if (c == null)
                return NotFound();
            else
                _db.News.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Messages()
        {
            var c = _db.ContactUs.ToList();
            return View(c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
