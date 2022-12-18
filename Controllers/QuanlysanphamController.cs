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

namespace BTLNhom3.Controllers
{
    public class QuanlysanphamController : Controller
    {
        private readonly MvcMovieContext _context;
        private ExcelsProcess _excelProcess = new ExcelsProcess();
        public QuanlysanphamController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Quanlysanpham
        public async Task<IActionResult> Index(string searchString)
        {
            var Masp = from m in _context.Quanlysanpham
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Masp = Masp.Where(s => s.Masanpham!.Contains(searchString));
                }
            return View(await Masp.ToListAsync());
        }

    //GET: Update
         public async Task<IActionResult>Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension !=".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename
                    var fileName = DateTime.Now.ToShortTimeString() +fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath,FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        // read data from
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for (int i=0; i< dt.Rows.Count;i++)
                        {
                            //create a new Customer object
                            var Qlsp = new Quanlysanpham();
                            // set values for attrinutes
                            Qlsp.Masanpham= dt.Rows[i][0].ToString();
                            Qlsp.Tensanpham= dt.Rows[i][1].ToString();
                            Qlsp.size = Convert.ToInt32(dt.Rows[i][2].ToString ());
                            Qlsp.soluong= Convert.ToInt32(dt.Rows[i][3].ToString ());
                            Qlsp.mausac = dt.Rows[i][4].ToString();
                            Qlsp.giatien = Convert.ToDecimal(dt.Rows[i][5].ToString ());

                             //add object to Context
                             _context.Quanlysanpham.Add(Qlsp);
                        }
                        //save to database 
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
        // GET: Quanlysanpham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Quanlysanpham == null)
            {
                return NotFound();
            }

            var quanlysanpham = await _context.Quanlysanpham
                .FirstOrDefaultAsync(m => m.Masanpham == id);
            if (quanlysanpham == null)
            {
                return NotFound();
            }

            return View(quanlysanpham);
        }

        // GET: Quanlysanpham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanlysanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masanpham,Tensanpham,size,soluong,mausac,giatien")] Quanlysanpham quanlysanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlysanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlysanpham);
        }

        // GET: Quanlysanpham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Quanlysanpham == null)
            {
                return NotFound();
            }

            var quanlysanpham = await _context.Quanlysanpham.FindAsync(id);
            if (quanlysanpham == null)
            {
                return NotFound();
            }
            return View(quanlysanpham);
        }

        // POST: Quanlysanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masanpham,Tensanpham,size,soluong,mausac,giatien")] Quanlysanpham quanlysanpham)
        {
            if (id != quanlysanpham.Masanpham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlysanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlysanphamExists(quanlysanpham.Masanpham))
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
            return View(quanlysanpham);
        }

        // GET: Quanlysanpham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Quanlysanpham == null)
            {
                return NotFound();
            }

            var quanlysanpham = await _context.Quanlysanpham
                .FirstOrDefaultAsync(m => m.Masanpham == id);
            if (quanlysanpham == null)
            {
                return NotFound();
            }

            return View(quanlysanpham);
        }

        // POST: Quanlysanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Quanlysanpham == null)
            {
                return Problem("Entity set 'MvcMovieContext.Quanlysanpham'  is null.");
            }
            var quanlysanpham = await _context.Quanlysanpham.FindAsync(id);
            if (quanlysanpham != null)
            {
                _context.Quanlysanpham.Remove(quanlysanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlysanphamExists(string id)
        {
          return (_context.Quanlysanpham?.Any(e => e.Masanpham == id)).GetValueOrDefault();
        }
    }
}
