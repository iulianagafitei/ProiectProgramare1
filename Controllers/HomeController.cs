using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgramareProiect.Models;
using Microsoft.EntityFrameworkCore;
using ProgramareProiect.Data;
using ProgramareProiect.Models.LibraryViewModels;

namespace ProgramareProiect.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Statistics()
        {
            IQueryable<RezervareGrup> data =
            from rezervare in _context.Rezervari
            group rezervare by rezervare.DataRezervare into dateGroup
            select new RezervareGrup()
            {
                DataRezervare = dateGroup.Key,
                NumarCamera = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }


        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CamerasController()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
