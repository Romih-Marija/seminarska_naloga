using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;


namespace web.Controllers
{
    public class UporabniskiRacuniController : Controller
    {
        private readonly oaContext _context;

        public UporabniskiRacuniController(oaContext context)
        {
            _context = context;
        }

        // GET: UporabniskiRacuni
        public async Task<IActionResult> Index()
        {
            return View(await _context.UporabniskiRacuni.ToListAsync());
        }

        // GET: UporabniskiRacuni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabniskiRacun = await _context.UporabniskiRacuni
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uporabniskiRacun == null)
            {
                return NotFound();
            }

            return View(uporabniskiRacun);
        }

        // GET: UporabniskiRacuni/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UporabniskiRacuni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,uporabniskoIme,eposta,geslo,EnrollmentDate")] UporabniskiRacun uporabniskiRacun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uporabniskiRacun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uporabniskiRacun);
        }

        // GET: UporabniskiRacuni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabniskiRacun = await _context.UporabniskiRacuni.FindAsync(id);
            if (uporabniskiRacun == null)
            {
                return NotFound();
            }
            return View(uporabniskiRacun);
        }

        // POST: UporabniskiRacuni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,uporabniskoIme,eposta,geslo,EnrollmentDate")] UporabniskiRacun uporabniskiRacun)
        {
            if (id != uporabniskiRacun.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uporabniskiRacun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UporabniskiRacunExists(uporabniskiRacun.ID))
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
            return View(uporabniskiRacun);
        }

        // GET: UporabniskiRacuni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabniskiRacun = await _context.UporabniskiRacuni
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uporabniskiRacun == null)
            {
                return NotFound();
            }

            return View(uporabniskiRacun);
        }

        // POST: UporabniskiRacuni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uporabniskiRacun = await _context.UporabniskiRacuni.FindAsync(id);
            if (uporabniskiRacun != null)
            {
                _context.UporabniskiRacuni.Remove(uporabniskiRacun);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UporabniskiRacunExists(int id)
        {
            return _context.UporabniskiRacuni.Any(e => e.ID == id);
        }
    }
}
