using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    [Authorize]
    public class NudimNadomescanjeController : Controller
    {
        private readonly oaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public NudimNadomescanjeController(oaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: NudimNadomescanje
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["PdDatumaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "" : "OdDatuma_desc";
            ViewData["DoDatumaSortParm"] = sortOrder == "DoDatuma" ? "DoDatuma_desc" : "DoDatuma_asc";
            ViewData["ImeSortParm"] = sortOrder == "Ime" ? "Ime_desc" : "Ime_asc";
            ViewData["PriimekSortParm"] = sortOrder == "Priimek" ? "Priimek_desc" : "Priimek_asc";
            ViewData["CurrentFilter"] = searchString;
   
            var nudimNadomescanje = from o in _context.NudimNadomescanje
                select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                nudimNadomescanje = nudimNadomescanje.Where(o => o.Ime.Contains(searchString)
                                    || o.Priimek.Contains(searchString) || o.Lokacija.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Ime_desc":
                    nudimNadomescanje = nudimNadomescanje.OrderByDescending(o => o.Ime);
                    break;
                case "Ime_asc":
                    nudimNadomescanje = nudimNadomescanje.OrderBy(o => o.Ime);
                    break;
                case "Priimek_desc":
                    nudimNadomescanje = nudimNadomescanje.OrderByDescending(o => o.Priimek);
                    break;
                case "Priimek_asc":
                    nudimNadomescanje = nudimNadomescanje.OrderBy(o => o.Priimek);
                    break;
                case "OdDatuma_desc":
                    nudimNadomescanje = nudimNadomescanje.OrderByDescending(o => o.OdDatuma);
                    break;
                case "DoDatuma_asc":
                    nudimNadomescanje = nudimNadomescanje.OrderBy(o => o.DoDatuma);
                    break;
                case "DoDatuma_desc":
                    nudimNadomescanje = nudimNadomescanje.OrderByDescending(o => o.DoDatuma);
                    break;
                default:
                    nudimNadomescanje = nudimNadomescanje.OrderBy(o => o.OdDatuma);
                    break;
            }
            return View(await nudimNadomescanje.AsNoTracking().ToListAsync());
        }


        // GET: NudimNadomescanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nudimNadomescanje = await _context.NudimNadomescanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nudimNadomescanje == null)
            {
                return NotFound();
            }

            return View(nudimNadomescanje);
        }

        // GET: NudimNadomescanje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NudimNadomescanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Priimek,Lokacija,OdDatuma,DoDatuma,AvtorObjave")] NudimNadomescanje nudimNadomescanje)
          {
            var currentUser = await _usermanager.GetUserAsync(User);
            var currUserName = currentUser.UserName;
            DateTime DT = DateTime.Now;
            if (ModelState.IsValid)
            {
                nudimNadomescanje.AvtorObjave = currUserName;
                _context.Add(nudimNadomescanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nudimNadomescanje);
        }

        // GET: NudimNadomescanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nudimNadomescanje = await _context.NudimNadomescanje.FindAsync(id);
            if (nudimNadomescanje == null)
            {
                return NotFound();
            }
            return View(nudimNadomescanje);
        }

        // POST: NudimNadomescanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Priimek,Lokacija,OdDatuma,DoDatuma,AvtorObjave")] NudimNadomescanje nudimNadomescanje)
        {
            if (id != nudimNadomescanje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nudimNadomescanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NudimNadomescanjeExists(nudimNadomescanje.ID))
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
            return View(nudimNadomescanje);
        }

        // GET: NudimNadomescanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nudimNadomescanje = await _context.NudimNadomescanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nudimNadomescanje == null)
            {
                return NotFound();
            }

            return View(nudimNadomescanje);
        }

        // POST: NudimNadomescanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nudimNadomescanje = await _context.NudimNadomescanje.FindAsync(id);
            if (nudimNadomescanje != null)
            {
                _context.NudimNadomescanje.Remove(nudimNadomescanje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NudimNadomescanjeExists(int id)
        {
            return _context.NudimNadomescanje.Any(e => e.ID == id);
        }
    }
}
