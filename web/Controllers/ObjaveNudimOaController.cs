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
    public class ObjaveNudimOaController : Controller
    {
        private readonly oaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ObjaveNudimOaController(oaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;

        }

        // GET: ObjaveNudimOa
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DatumObjaveSortParm"] = String.IsNullOrEmpty(sortOrder) ? "" : "Datum_desc";
            ViewData["ImeSortParm"] = sortOrder == "Ime" ? "Ime_desc" : "Ime_asc";
            ViewData["PriimekSortParm"] = sortOrder == "Priimek" ? "Priimek_desc" : "Priimek_asc";
            ViewData["CurrentFilter"] = searchString;
   
            var objaveNudim = from o in _context.ObjaveNudimOa
                select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                objaveNudim = objaveNudim.Where(o => o.Ime.Contains(searchString)
                                    || o.Priimek.Contains(searchString) || o.Lokacija.Contains(searchString)
                                    );
            }
            switch (sortOrder)
            {
                case "Ime_desc":
                    objaveNudim = objaveNudim.OrderByDescending(o => o.Ime);
                    break;
                case "Ime_asc":
                    objaveNudim = objaveNudim.OrderBy(o => o.Ime);
                    break;
                case "Priimek_desc":
                    objaveNudim = objaveNudim.OrderByDescending(o => o.Priimek);
                    break;
                case "Priimek_asc":
                    objaveNudim = objaveNudim.OrderBy(o => o.Priimek);
                    break;
                case "Datum_desc":
                    objaveNudim = objaveNudim.OrderByDescending(o => o.DatumObjave);
                    break;
                default:
                    objaveNudim = objaveNudim.OrderBy(o => o.DatumObjave);
                    break;
            }
            return View(await objaveNudim.AsNoTracking().ToListAsync());
        }
        

        // GET: ObjaveNudimOa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaNudimOa = await _context.ObjaveNudimOa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objavaNudimOa == null)
            {
                return NotFound();
            }

            return View(objavaNudimOa);
        }

        // GET: ObjaveNudimOa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjaveNudimOa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Priimek,Lokacija,Opis,DatumObjave,AvtorObjave")] ObjavaNudimOa objavaNudimOa)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            var currUserName = currentUser.UserName;
            DateTime DT = DateTime.Now;
            if (ModelState.IsValid)
            {
                objavaNudimOa.DatumObjave = DT;
                objavaNudimOa.AvtorObjave = currUserName;
                _context.Add(objavaNudimOa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objavaNudimOa);
        }

        // GET: ObjaveNudimOa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaNudimOa = await _context.ObjaveNudimOa.FindAsync(id);
            if (objavaNudimOa == null)
            {
                return NotFound();
            }
            return View(objavaNudimOa);
        }

        // POST: ObjaveNudimOa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Priimek,Lokacija,Opis,DatumObjave,AvtorObjave")] ObjavaNudimOa objavaNudimOa)
        {
            if (id != objavaNudimOa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objavaNudimOa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjavaNudimOaExists(objavaNudimOa.ID))
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
            return View(objavaNudimOa);
        }

        // GET: ObjaveNudimOa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaNudimOa = await _context.ObjaveNudimOa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objavaNudimOa == null)
            {
                return NotFound();
            }

            return View(objavaNudimOa);
        }

        // POST: ObjaveNudimOa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objavaNudimOa = await _context.ObjaveNudimOa.FindAsync(id);
            if (objavaNudimOa != null)
            {
                _context.ObjaveNudimOa.Remove(objavaNudimOa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjavaNudimOaExists(int id)
        {
            return _context.ObjaveNudimOa.Any(e => e.ID == id);
        }
    }
}
