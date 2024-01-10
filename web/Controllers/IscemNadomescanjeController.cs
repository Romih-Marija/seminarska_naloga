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
    public class IscemNadomescanjeController : Controller
    {
        private readonly oaContext _context;

        public IscemNadomescanjeController(oaContext context)
        {
            _context = context;
        }

        // GET: IscemNadomescanje
        public async Task<IActionResult> Index()
        {
            return View(await _context.IscemNadomescanje.ToListAsync());
        }

        // GET: IscemNadomescanje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iscemNadomescanje = await _context.IscemNadomescanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (iscemNadomescanje == null)
            {
                return NotFound();
            }

            return View(iscemNadomescanje);
        }

        // GET: IscemNadomescanje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IscemNadomescanje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Priimek,Lokacija,OdDatuma,DoDatuma,AvtorObjave")] IscemNadomescanje iscemNadomescanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iscemNadomescanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iscemNadomescanje);
        }

        // GET: IscemNadomescanje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iscemNadomescanje = await _context.IscemNadomescanje.FindAsync(id);
            if (iscemNadomescanje == null)
            {
                return NotFound();
            }
            return View(iscemNadomescanje);
        }

        // POST: IscemNadomescanje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Priimek,Lokacija,OdDatuma,DoDatuma,AvtorObjave")] IscemNadomescanje iscemNadomescanje)
        {
            if (id != iscemNadomescanje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iscemNadomescanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IscemNadomescanjeExists(iscemNadomescanje.ID))
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
            return View(iscemNadomescanje);
        }

        // GET: IscemNadomescanje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iscemNadomescanje = await _context.IscemNadomescanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (iscemNadomescanje == null)
            {
                return NotFound();
            }

            return View(iscemNadomescanje);
        }

        // POST: IscemNadomescanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iscemNadomescanje = await _context.IscemNadomescanje.FindAsync(id);
            if (iscemNadomescanje != null)
            {
                _context.IscemNadomescanje.Remove(iscemNadomescanje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IscemNadomescanjeExists(int id)
        {
            return _context.IscemNadomescanje.Any(e => e.ID == id);
        }
    }
}
