using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenNGocLongVu_33.Models;

namespace NguyenNGocLongVu_33.Controllers
{
    public class LopHocController : Controller
    {
        private readonly LTQLDD _context;

        public LopHocController(LTQLDD context)
        {
            _context = context;
        }

        // GET: LopHoc
        public async Task<IActionResult> Index()
        {
              return _context.LopHoc != null ? 
                          View(await _context.LopHoc.ToListAsync()) :
                          Problem("Entity set 'LTQLDD.LopHoc'  is null.");
        }

        // GET: LopHoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // GET: LopHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LopHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLop,TenLop")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        // GET: LopHoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLop,TenLop")] LopHoc lopHoc)
        {
            if (id != lopHoc.MaLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHoc.MaLop))
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
            return View(lopHoc);
        }

        // GET: LopHoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LopHoc == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // POST: LopHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LopHoc == null)
            {
                return Problem("Entity set 'LTQLDD.LopHoc'  is null.");
            }
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHoc.Remove(lopHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(string id)
        {
          return (_context.LopHoc?.Any(e => e.MaLop == id)).GetValueOrDefault();
        }
    }
}
