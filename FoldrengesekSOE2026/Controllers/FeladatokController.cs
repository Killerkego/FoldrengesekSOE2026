using FoldrengesekSOE2026.Data;
using FoldrengesekSOE2026.Services;
using FoldrengesekSOE2026.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoldrengesekSOE2026.Controllers
{
    [Authorize(Roles ="User, Admin")]
    public class FeladatokController : Controller
    {
        private readonly FoldrengesContext _context;
        private readonly ILekerdezesiFeladatok _queries;

        public FeladatokController(FoldrengesContext context, ILekerdezesiFeladatok queries)
        {
            _context = context;
            _queries = queries;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Feladat2()
        {
            var results = _queries.SomogyTelepulesNevek();

            return View(results);
        }


        public IActionResult Feladat3()
        {
            var results = _queries.VarmegyeiRengesSzamok();

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
                            Magnitudo = naplo.Magnitudo
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
                            Intenzitas = naplo.Intenzitas
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
