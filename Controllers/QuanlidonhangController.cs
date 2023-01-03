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
    public class QuanlidonhangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanlidonhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quanlidonhang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quanlidonhang.Include(q => q.Quanlikhachhang).Include(q => q.Quanlisanpham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Quanlidonhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlidonhang == null)
            {
                return NotFound();
            }

            var quanlidonhang = await _context.Quanlidonhang
                .Include(q => q.Quanlikhachhang)
                .Include(q => q.Quanlisanpham)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanlidonhang == null)
            {
                return NotFound();
            }

            return View(quanlidonhang);
        }

        // GET: Quanlidonhang/Create
        public IActionResult Create()
        {
            ViewData["Makhachhang"] = new SelectList(_context.Quanlikhachhang, "Makhachhang", "Makhachhang");
            ViewData["Masanpham"] = new SelectList(_context.Quanlisanpham, "Masanpham", "Masanpham");
            return View();
        }

        // POST: Quanlidonhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madonhang,ngay,Masanpham,Makhachhang")] Quanlidonhang quanlidonhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlidonhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhachhang"] = new SelectList(_context.Quanlikhachhang, "Makhachhang", "Makhachhang", quanlidonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlisanpham, "Masanpham", "Masanpham", quanlidonhang.Masanpham);
            return View(quanlidonhang);
        }

        // GET: Quanlidonhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlidonhang == null)
            {
                return NotFound();
            }

            var quanlidonhang = await _context.Quanlidonhang.FindAsync(id);
            if (quanlidonhang == null)
            {
                return NotFound();
            }
            ViewData["Makhachhang"] = new SelectList(_context.Quanlikhachhang, "Makhachhang", "Makhachhang", quanlidonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlisanpham, "Masanpham", "Masanpham", quanlidonhang.Masanpham);
            return View(quanlidonhang);
        }

        // POST: Quanlidonhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Madonhang,ngay,Masanpham,Makhachhang")] Quanlidonhang quanlidonhang)
        {
            if (id != quanlidonhang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlidonhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlidonhangExists(quanlidonhang.Madonhang))
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
            ViewData["Makhachhang"] = new SelectList(_context.Quanlikhachhang, "Makhachhang", "Makhachhang", quanlidonhang.Makhachhang);
            ViewData["Masanpham"] = new SelectList(_context.Quanlisanpham, "Masanpham", "Masanpham", quanlidonhang.Masanpham);
            return View(quanlidonhang);
        }

        // GET: Quanlidonhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlidonhang == null)
            {
                return NotFound();
            }

            var quanlidonhang = await _context.Quanlidonhang
                .Include(q => q.Quanlikhachhang)
                .Include(q => q.Quanlisanpham)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanlidonhang == null)
            {
                return NotFound();
            }

            return View(quanlidonhang);
        }

        // POST: Quanlidonhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlidonhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quanlidonhang'  is null.");
            }
            var quanlidonhang = await _context.Quanlidonhang.FindAsync(id);
            if (quanlidonhang != null)
            {
                _context.Quanlidonhang.Remove(quanlidonhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlidonhangExists(string id)
        {
          return (_context.Quanlidonhang?.Any(e => e.Madonhang == id)).GetValueOrDefault();
        }
    }
}
