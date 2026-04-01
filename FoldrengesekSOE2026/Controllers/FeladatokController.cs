using FoldrengesekSOE2026.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoldrengesekSOE2026.Controllers
{
    public class FeladatokController : Controller
    {
        private readonly FoldrengesContext _context;

        public FeladatokController(FoldrengesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Feladat2()
        {
            var results = _context.Telepulesek
                .Where(t => t.Varmegye == "Somogy")
                .OrderBy(t => t.Nev)
                .Select(t => t.Nev);

            return View(results);
        }

        public IActionResult Feladat3()
        {
            return View();
        }
        public IActionResult Feladat4()
        {
            return View();
        }
        public IActionResult Feladat5()
        {
            return View();
        }
        public IActionResult Feladat6()
        {
            return View();
        }
    }
}
