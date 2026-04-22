using FoldrengesekSOE2026.Data;
using FoldrengesekSOE2026.ViewModels;
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
            var results = _context.Telepulesek
                .Join(_context.Naplok,
                        telepules => telepules.ID,
                        naplo => naplo.TelepulesID,
                        (telepules, naplo) => new
                        {
                            telepules.Varmegye
                        })
                .GroupBy(t => t.Varmegye)
                .Select(g => new Feladat3ViewModel
                {
                    Varmegye = g.Key, // a mező, ami szerint csoportosítva van: Varmegye
                    Count = g.Count()
                })
                .OrderByDescending(t => t.Count);

            return View(results);
        }

        public IActionResult Feladat4()
        {
            var result = _context.Telepulesek
                .Join(_context.Naplok,
                        telepules => telepules.ID,
                        naplo => naplo.TelepulesID,
                        (telepules, naplo) => new Feladat4ViewModel
                        {
                            Nev = telepules.Nev,
                            Datum = naplo.Datum,
                            Ido = naplo.Ido,
                            Magnitudo = (decimal)naplo.Magnitudo
                        })
                .OrderByDescending(j => j.Magnitudo)
                .FirstOrDefault();

            return View(result);
        }

        public IActionResult Feladat5()
        {
            var results = _context.Telepulesek
                .Join(_context.Naplok,
                        telepules => telepules.ID,
                        naplo => naplo.TelepulesID,
                        (telepules, naplo) => new Feladat5ViewModel
                        {
                            Nev = telepules.Nev,
                            Datum = naplo.Datum,
                            Intenzitas = (decimal)naplo.Intenzitas
                        })
                .Where(j => j.Datum.Year == 2022 && j.Intenzitas >= 2 && j.Intenzitas <= 3)
                .OrderBy(j => j.Datum);

            return View(results);
        }

        public IActionResult Feladat6()
        {
            var results = _context.Naplok
                .Where(n => n.Intenzitas > 3)
                .GroupBy(n => n.Datum.Year)
                .Select(g => new Feladat6ViewModel
                {
                    Year = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .Take(3);

            return View(results);
        }

    }
}
