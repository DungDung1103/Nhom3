
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom3.Models;
using MvcMovie.Data;
using BTLNhom3.Models.Process;
using Microsoft.AspNetCore.Authorization;

namespace BTLNhom3.Controllers
{
   
    public class QuanlykhachhangController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();
        public QuanlykhachhangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Quanlykhachhang
        public async Task<IActionResult> Index()
        {
              return _context.Quanlykhachhang != null ? 
                          View(await _context.Quanlykhachhang.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Quanlykhachhang'  is null.");
        }

        // GET: Quanlykhachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }

            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhang/Create
      public IActionResult Create()
        {
            var newMakhachhang= "KH001";
            var countQuanlykhachhang = _context.Quanlykhachhang.Count();
            if(countQuanlykhachhang>0)
            {
                var Makhachhang = _context.Quanlykhachhang.OrderByDescending(m =>m.Makhachhang).First().Makhachhang;
                // sinh ma tu dong
                newMakhachhang = strPro.AutoGenerateCode(Makhachhang);
            }
            ViewBag.newID = newMakhachhang;
            return View(); 
            // ViewData["Mamonhoc"]=new SelectList (_context.Mamonhoc, "FacultyID", "FacultyName");
        }

        // POST: Quanlykhachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Quanlykhachhang quanlykhachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlykhachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang.FindAsync(id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }
            return View(quanlykhachhang);
        }

        // POST: Quanlykhachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Quanlykhachhang quanlykhachhang)
        {
            if (id != quanlykhachhang.Makhachhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlykhachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlykhachhangExists(quanlykhachhang.Makhachhang))
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
            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }

            return View(quanlykhachhang);
        }

        // POST: Quanlykhachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlykhachhang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Quanlykhachhang'  is null.");
            }
            var quanlykhachhang = await _context.Quanlykhachhang.FindAsync(id);
            if (quanlykhachhang != null)
            {
                _context.Quanlykhachhang.Remove(quanlykhachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlykhachhangExists(string id)
        {
          return (_context.Quanlykhachhang?.Any(e => e.Makhachhang == id)).GetValueOrDefault();
        }
    }
}
