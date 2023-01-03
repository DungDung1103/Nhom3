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
    public class QuanlikhachhangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanlikhachhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quanlikhachhang
        public async Task<IActionResult> Index()
        {
              return _context.Quanlikhachhang != null ? 
                          View(await _context.Quanlikhachhang.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Quanlikhachhang'  is null.");
        }

        // GET: Quanlikhachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlikhachhang == null)
            {
                return NotFound();
            }

            var quanlikhachhang = await _context.Quanlikhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (quanlikhachhang == null)
            {
                return NotFound();
            }

            return View(quanlikhachhang);
        }

        // GET: Quanlikhachhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanlikhachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Quanlikhachhang quanlikhachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlikhachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlikhachhang);
        }

        // GET: Quanlikhachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlikhachhang == null)
            {
                return NotFound();
            }

            var quanlikhachhang = await _context.Quanlikhachhang.FindAsync(id);
            if (quanlikhachhang == null)
            {
                return NotFound();
            }
            return View(quanlikhachhang);
        }

        // POST: Quanlikhachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Quanlikhachhang quanlikhachhang)
        {
            if (id != quanlikhachhang.Makhachhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlikhachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlikhachhangExists(quanlikhachhang.Makhachhang))
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
            return View(quanlikhachhang);
        }

        // GET: Quanlikhachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlikhachhang == null)
            {
                return NotFound();
            }

            var quanlikhachhang = await _context.Quanlikhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (quanlikhachhang == null)
            {
                return NotFound();
            }

            return View(quanlikhachhang);
        }

        // POST: Quanlikhachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlikhachhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quanlikhachhang'  is null.");
            }
            var quanlikhachhang = await _context.Quanlikhachhang.FindAsync(id);
            if (quanlikhachhang != null)
            {
                _context.Quanlikhachhang.Remove(quanlikhachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlikhachhangExists(string id)
        {
          return (_context.Quanlikhachhang?.Any(e => e.Makhachhang == id)).GetValueOrDefault();
        }
    }
}
