using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_Nhom3.Data;
using BTL_Nhom3.Models;

namespace BTL_Nhom3.Controllers
{
    public class QuanlisanphamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanlisanphamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quanlisanpham
        public async Task<IActionResult> Index()
        {
              return _context.Quanlisanpham != null ? 
                          View(await _context.Quanlisanpham.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Quanlisanpham'  is null.");
        }

        // GET: Quanlisanpham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlisanpham == null)
            {
                return NotFound();
            }

            var quanlisanpham = await _context.Quanlisanpham
                .FirstOrDefaultAsync(m => m.Masanpham == id);
            if (quanlisanpham == null)
            {
                return NotFound();
            }

            return View(quanlisanpham);
        }

        // GET: Quanlisanpham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanlisanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masanpham,Tensanpham,size,soluong,mausac,giatien")] Quanlisanpham quanlisanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlisanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlisanpham);
        }

        // GET: Quanlisanpham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlisanpham == null)
            {
                return NotFound();
            }

            var quanlisanpham = await _context.Quanlisanpham.FindAsync(id);
            if (quanlisanpham == null)
            {
                return NotFound();
            }
            return View(quanlisanpham);
        }

        // POST: Quanlisanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masanpham,Tensanpham,size,soluong,mausac,giatien")] Quanlisanpham quanlisanpham)
        {
            if (id != quanlisanpham.Masanpham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlisanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlisanphamExists(quanlisanpham.Masanpham))
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
            return View(quanlisanpham);
        }

        // GET: Quanlisanpham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlisanpham == null)
            {
                return NotFound();
            }

            var quanlisanpham = await _context.Quanlisanpham
                .FirstOrDefaultAsync(m => m.Masanpham == id);
            if (quanlisanpham == null)
            {
                return NotFound();
            }

            return View(quanlisanpham);
        }

        // POST: Quanlisanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlisanpham == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quanlisanpham'  is null.");
            }
            var quanlisanpham = await _context.Quanlisanpham.FindAsync(id);
            if (quanlisanpham != null)
            {
                _context.Quanlisanpham.Remove(quanlisanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlisanphamExists(string id)
        {
          return (_context.Quanlisanpham?.Any(e => e.Masanpham == id)).GetValueOrDefault();
        }
    }
}
