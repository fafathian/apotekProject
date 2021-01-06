using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apotek.Models;

namespace apotek.Controllers
{
    public class ApotekersController : Controller
    {
        private readonly ApotekPAWContext _context;

        public ApotekersController(ApotekPAWContext context)
        {
            _context = context;
        }

        // GET: Apotekers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apoteker.ToListAsync());
        }

        // GET: Apotekers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoteker = await _context.Apoteker
                .FirstOrDefaultAsync(m => m.IdApoteker == id);
            if (apoteker == null)
            {
                return NotFound();
            }

            return View(apoteker);
        }

        // GET: Apotekers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apotekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdApoteker,Username,Password")] Apoteker apoteker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apoteker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apoteker);
        }

        // GET: Apotekers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoteker = await _context.Apoteker.FindAsync(id);
            if (apoteker == null)
            {
                return NotFound();
            }
            return View(apoteker);
        }

        // POST: Apotekers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdApoteker,Username,Password")] Apoteker apoteker)
        {
            if (id != apoteker.IdApoteker)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apoteker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApotekerExists(apoteker.IdApoteker))
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
            return View(apoteker);
        }

        // GET: Apotekers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apoteker = await _context.Apoteker
                .FirstOrDefaultAsync(m => m.IdApoteker == id);
            if (apoteker == null)
            {
                return NotFound();
            }

            return View(apoteker);
        }

        // POST: Apotekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apoteker = await _context.Apoteker.FindAsync(id);
            _context.Apoteker.Remove(apoteker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApotekerExists(int id)
        {
            return _context.Apoteker.Any(e => e.IdApoteker == id);
        }
    }
}
