using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using System.Linq;

namespace NewsApp.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DefaultController : Controller
    {
        private readonly NewsContext db;

        public DefaultController(NewsContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            int teamcount = db.TeamMembers.Count();
            int newscount = db.News.Count();
            int contactcount = db.ContactUs.Count();
            int catcount = db.Categories.Count();
            return View(new AdminNumber { team=teamcount,news=newscount,concat=contactcount,cat=catcount});
        }
    }
    public class AdminNumber
    {
        public int team { get; set; }
        public int news { get; set; }
        public int concat { get; set; }
        public int cat { get; set; }
    }
}
