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
    public class ObjaveIscemOaController : Controller
    {
        private readonly oaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ObjaveIscemOaController(oaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: ObjaveIscemOa
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjaveIscemOa.ToListAsync());
        }

        // GET: ObjaveIscemOa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaIscemOa = await _context.ObjaveIscemOa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objavaIscemOa == null)
            {
                return NotFound();
            }

            return View(objavaIscemOa);
        }

        // GET: ObjaveIscemOa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjaveIscemOa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Priimek,Lokacija,DelovniCas,Opis")] ObjavaIscemOa objavaIscemOa)
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            var currUserName = currentUser.UserName;
            DateTime DT = DateTime.Now;
            if (ModelState.IsValid)
            {
                objavaIscemOa.DatumObjave = DT;
                objavaIscemOa.AvtorObjave = currUserName;
                _context.Add(objavaIscemOa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objavaIscemOa);
        }

        // GET: ObjaveIscemOa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaIscemOa = await _context.ObjaveIscemOa.FindAsync(id);
            if (objavaIscemOa == null)
            {
                return NotFound();
            }
            return View(objavaIscemOa);
        }

        // POST: ObjaveIscemOa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Priimek,Lokacija,DelovniCas,Opis")] ObjavaIscemOa objavaIscemOa)
        {
            if (id != objavaIscemOa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objavaIscemOa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjavaIscemOaExists(objavaIscemOa.ID))
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
            return View(objavaIscemOa);
        }

        // GET: ObjaveIscemOa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objavaIscemOa = await _context.ObjaveIscemOa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objavaIscemOa == null)
            {
                return NotFound();
            }

            return View(objavaIscemOa);
        }

        // POST: ObjaveIscemOa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objavaIscemOa = await _context.ObjaveIscemOa.FindAsync(id);
            if (objavaIscemOa != null)
            {
                _context.ObjaveIscemOa.Remove(objavaIscemOa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjavaIscemOaExists(int id)
        {
            return _context.ObjaveIscemOa.Any(e => e.ID == id);
        }
    }
}
