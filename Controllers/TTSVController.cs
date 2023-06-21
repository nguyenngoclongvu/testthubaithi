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
    public class TTSVController : Controller
    {
        private readonly LTQLDD _context;

        public TTSVController(LTQLDD context)
        {
            _context = context;
        }

        // GET: TTSV
        public async Task<IActionResult> Index()
        {
            var lTQLDD = _context.TTSV.Include(t => t.LopHoc);
            return View(await lTQLDD.ToListAsync());
        }

        // GET: TTSV/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TTSV == null)
            {
                return NotFound();
            }

            var tTSV = await _context.TTSV
                .Include(t => t.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSinhvien == id);
            if (tTSV == null)
            {
                return NotFound();
            }

            return View(tTSV);
        }

        // GET: TTSV/Create
        public IActionResult Create()
        {
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop");
            return View();
        }

        // POST: TTSV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhvien,HoTen,MaLop")] TTSV tTSV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tTSV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", tTSV.MaLop);
            return View(tTSV);
        }

        // GET: TTSV/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TTSV == null)
            {
                return NotFound();
            }

            var tTSV = await _context.TTSV.FindAsync(id);
            if (tTSV == null)
            {
                return NotFound();
            }
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", tTSV.MaLop);
            return View(tTSV);
        }

        // POST: TTSV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSinhvien,HoTen,MaLop")] TTSV tTSV)
        {
            if (id != tTSV.MaSinhvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTSV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTSVExists(tTSV.MaSinhvien))
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
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", tTSV.MaLop);
            return View(tTSV);
        }

        // GET: TTSV/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TTSV == null)
            {
                return NotFound();
            }

            var tTSV = await _context.TTSV
                .Include(t => t.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSinhvien == id);
            if (tTSV == null)
            {
                return NotFound();
            }

            return View(tTSV);
        }

        // POST: TTSV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TTSV == null)
            {
                return Problem("Entity set 'LTQLDD.TTSV'  is null.");
            }
            var tTSV = await _context.TTSV.FindAsync(id);
            if (tTSV != null)
            {
                _context.TTSV.Remove(tTSV);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTSVExists(string id)
        {
          return (_context.TTSV?.Any(e => e.MaSinhvien == id)).GetValueOrDefault();
        }
    }
}
