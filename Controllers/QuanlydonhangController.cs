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
    public class QuanlydonhangController : Controller
    {
        private readonly MvcMovieContext _context;

        public QuanlydonhangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Quanlydonhang
       public async Task<IActionResult> Index(string searchString)
        {
            var Madh = from m in _context.Quanlydonhang
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Madh = Madh.Where(s => s.Madonhang!.Contains(searchString));
                }
            return View(await Madh.ToListAsync());
        }

        // GET: Quanlydonhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlydonhang == null)
            {
                return NotFound();
            }

            var quanlydonhang = await _context.Quanlydonhang
                .Include(q => q.Quanlykhachhang)
                .Include(q => q.Quanlysanpham)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanlydonhang == null)
            {
                return NotFound();
            }

            return View(quanlydonhang);
        }

        // GET: Quanlydonhang/Create
        public IActionResult Create()
        {
            ViewData["Makhachhang"] = new SelectList(_context.Quanlykhachhang, "Makhachhang", "Makhachhang");
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham");
            return View();
        }

        // POST: Quanlydonhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madonhang,ngaylamnv,Masanpham,Makhachhang")] Quanlydonhang quanlydonhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlydonhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhachhang"] = new SelectList(_context.Quanlykhachhang, "Makhachhang", "Makhachhang", quanlydonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham", quanlydonhang.Masanpham);
            return View(quanlydonhang);
        }

        // GET: Quanlydonhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlydonhang == null)
            {
                return NotFound();
            }

            var quanlydonhang = await _context.Quanlydonhang.FindAsync(id);
            if (quanlydonhang == null)
            {
                return NotFound();
            }
            ViewData["Makhachhang"] = new SelectList(_context.Quanlykhachhang, "Makhachhang", "Makhachhang", quanlydonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham", quanlydonhang.Masanpham);
            return View(quanlydonhang);
        }

        // POST: Quanlydonhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Madonhang,ngaylamnv,Masanpham,Makhachhang")] Quanlydonhang quanlydonhang)
        {
            if (id != quanlydonhang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlydonhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlydonhangExists(quanlydonhang.Madonhang))
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
            ViewData["Makhachhang"] = new SelectList(_context.Quanlykhachhang, "Makhachhang", "Makhachhang", quanlydonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlysanpham, "Masanpham", "Masanpham", quanlydonhang.Masanpham);
            return View(quanlydonhang);
        }

        // GET: Quanlydonhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlydonhang == null)
            {
                return NotFound();
            }

            var quanlydonhang = await _context.Quanlydonhang
                .Include(q => q.Quanlykhachhang)
                .Include(q => q.Quanlysanpham)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanlydonhang == null)
            {
                return NotFound();
            }

            return View(quanlydonhang);
        }

        // POST: Quanlydonhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlydonhang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Quanlydonhang'  is null.");
            }
            var quanlydonhang = await _context.Quanlydonhang.FindAsync(id);
            if (quanlydonhang != null)
            {
                _context.Quanlydonhang.Remove(quanlydonhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlydonhangExists(string id)
        {
          return (_context.Quanlydonhang?.Any(e => e.Madonhang == id)).GetValueOrDefault();
        }
    }
}
