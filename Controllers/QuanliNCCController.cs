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
    public class QuanliNCCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanliNCCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuanliNCC
        public async Task<IActionResult> Index()
        {
              return _context.QuanliNCC != null ? 
                          View(await _context.QuanliNCC.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuanliNCC'  is null.");
        }

        // GET: QuanliNCC/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QuanliNCC == null)
            {
                return NotFound();
            }

            var quanliNCC = await _context.QuanliNCC
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (quanliNCC == null)
            {
                return NotFound();
            }

            return View(quanliNCC);
        }

        // GET: QuanliNCC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanliNCC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNCC,TenNCC,Sodienthoai,Diachi,Emai")] QuanliNCC quanliNCC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanliNCC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanliNCC);
        }

        // GET: QuanliNCC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QuanliNCC == null)
            {
                return NotFound();
            }

            var quanliNCC = await _context.QuanliNCC.FindAsync(id);
            if (quanliNCC == null)
            {
                return NotFound();
            }
            return View(quanliNCC);
        }

        // POST: QuanliNCC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNCC,TenNCC,Sodienthoai,Diachi,Emai")] QuanliNCC quanliNCC)
        {
            if (id != quanliNCC.MaNCC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanliNCC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanliNCCExists(quanliNCC.MaNCC))
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
            return View(quanliNCC);
        }

        // GET: QuanliNCC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QuanliNCC == null)
            {
                return NotFound();
            }

            var quanliNCC = await _context.QuanliNCC
                .FirstOrDefaultAsync(m => m.MaNCC == id);
            if (quanliNCC == null)
            {
                return NotFound();
            }

            return View(quanliNCC);
        }

        // POST: QuanliNCC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QuanliNCC == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuanliNCC'  is null.");
            }
            var quanliNCC = await _context.QuanliNCC.FindAsync(id);
            if (quanliNCC != null)
            {
                _context.QuanliNCC.Remove(quanliNCC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanliNCCExists(string id)
        {
          return (_context.QuanliNCC?.Any(e => e.MaNCC == id)).GetValueOrDefault();
        }
    }
}
