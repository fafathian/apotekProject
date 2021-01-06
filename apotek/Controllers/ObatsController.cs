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
    public class ObatsController : Controller
    {
        private readonly ApotekPAWContext _context;

        public ObatsController(ApotekPAWContext context)
        {
            _context = context;
        }

        // GET: Obats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Obat.ToListAsync());
        }

        // GET: Obats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obat = await _context.Obat
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (obat == null)
            {
                return NotFound();
            }

            return View(obat);
        }

        // GET: Obats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Obats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObat,NamaObat,JenisObat,Harga,Quantity")] Obat obat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obat);
        }

        // GET: Obats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obat = await _context.Obat.FindAsync(id);
            if (obat == null)
            {
                return NotFound();
            }
            return View(obat);
        }

        // POST: Obats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObat,NamaObat,JenisObat,Harga,Quantity")] Obat obat)
        {
            if (id != obat.IdObat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObatExists(obat.IdObat))
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
            return View(obat);
        }

        // GET: Obats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obat = await _context.Obat
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (obat == null)
            {
                return NotFound();
            }

            return View(obat);
        }

        // POST: Obats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obat = await _context.Obat.FindAsync(id);
            _context.Obat.Remove(obat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObatExists(int id)
        {
            return _context.Obat.Any(e => e.IdObat == id);
        }
    }
}
