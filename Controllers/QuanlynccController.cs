using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom3.Models;
using MvcMovie.Data;

namespace BTLNhom3.Controllers
{
    public class QuanlynccController : Controller
    {
        private readonly MvcMovieContext _context;

        public QuanlynccController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Quanlyncc
        public async Task<IActionResult> Index()
        {
           
            // return View(await MvcMovieContext.ToListAsync());
            return _context.Quanlyncc != null ? 
                          View(await _context.Quanlyncc.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Quanlykhachhang'  is null.");
        }

        // GET: Quanlyncc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlyncc == null)
            {
                return NotFound();
            }

            var quanlyncc = await _context.Quanlyncc

                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (quanlyncc == null)
            {
                return NotFound();
            }

            return View(quanlyncc);
        }

        // GET: Quanlyncc/Create
        public IActionResult Create()
        {
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham");
            return View();
        }

        // POST: Quanlyncc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masanncc,Tenncc,sodienthoai,diachi,email,Masanpham")] Quanlyncc quanlyncc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlyncc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham");
            return View(quanlyncc);
        }

        // GET: Quanlyncc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlyncc == null)
            {
                return NotFound();
            }

            var quanlyncc = await _context.Quanlyncc.FindAsync(id);
            if (quanlyncc == null)
            {
                return NotFound();
            }
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham" );
            return View(quanlyncc);
        }

        // POST: Quanlyncc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masanncc,Tenncc,sodienthoai,diachi,email,Masanpham")] Quanlyncc quanlyncc)
        {
            if (id != quanlyncc.Mancc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlyncc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlynccExists(quanlyncc.Mancc))
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
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham");
            return View(quanlyncc);
        }

        // GET: Quanlyncc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlyncc == null)
            {
                return NotFound();
            }

            var quanlyncc = await _context.Quanlyncc
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (quanlyncc == null)
            {
                return NotFound();
            }

            return View(quanlyncc);
        }

        // POST: Quanlyncc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlyncc == null)
            {
                return Problem("Entity set 'MvcMovieContext.Quanlyncc'  is null.");
            }
            var quanlyncc = await _context.Quanlyncc.FindAsync(id);
            if (quanlyncc != null)
            {
                _context.Quanlyncc.Remove(quanlyncc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlynccExists(string id)
        {
          return (_context.Quanlyncc?.Any(e => e.Mancc == id)).GetValueOrDefault();
        }
    }
}
