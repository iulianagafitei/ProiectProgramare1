using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramareProiect.Data;
using ProgramareProiect.Models;

namespace ProgramareProiect.Controllers
{

    public class CamerasController : Controller
    {
        private readonly LibraryContext _context;

        public CamerasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Cameras
        /*  public async Task<IActionResult> Index()
          {
              return View(await _context.Camere.ToListAsync());
          } */

        public async Task<IActionResult> Index(string Sortare, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = Sortare;
            ViewData["TipPatSortParm"] = String.IsNullOrEmpty(Sortare) ? "TipPat_desc" : "";
            ViewData["PretNoapteSortParm"] = Sortare == "PretNoapte" ? "PretNoapte_desc" : "PretNoapte";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var camere = from c in _context.Camere
                         select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                camere = camere.Where(s => s.TipPat.Contains(searchString));
            }
            switch (Sortare)
            {
                case "TipPat_desc":
                    camere = camere.OrderByDescending(c => c.TipPat);
                    break;
                case "PretNoapte":
                    camere = camere.OrderBy(c => c.PretNoapte);
                    break;
                case "PretNoapte_desc":
                    camere = camere.OrderByDescending(c => c.PretNoapte);
                    break;
                default:
                    camere = camere.OrderBy(c => c.TipPat);
                    break;
            }
            int pageSize = 5;
            return View(await Pagini<Camera>.CreateAsync(camere.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Cameras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camere
                .Include(s => s.Rezervari)
                .ThenInclude(e => e.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CameraID == id);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        // GET: Cameras/Create
         public IActionResult Create()
         {
             return View();
         }



        // POST: Cameras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("CameraID,Etaj,TipPat,PretNoapte")] Camera camera)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(camera);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            return View(camera);
        }

        // GET: Cameras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camere.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CameraID,Etaj,TipPat,PretNoapte")] Camera camera)
        {
            if (id != camera.CameraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraExists(camera.CameraID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(camera);
        }*/

        // GET: Cameras/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camere
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CameraID == id);
            if (camera == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }

            return View(camera);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Camere.FirstOrDefaultAsync(s => s.CameraID == id);
            if (await TryUpdateModelAsync<Camera>(studentToUpdate, "", s => s.CameraID, s => s.Etaj, s => s.TipPat, s => s.PretNoapte))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(studentToUpdate);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camera = await _context.Camere.FindAsync(id);
            if (camera == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Camere.Remove(camera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException /* ex */)
            {

                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
        }

        private bool CameraExists(int id)
        {
            return _context.Camere.Any(e => e.CameraID == id);
        }
    }
}
