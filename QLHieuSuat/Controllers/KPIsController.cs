using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLHieuSuat.Models;

namespace QLHieuSuat.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KPIsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KPIsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KPIs
        public async Task<IActionResult> Index()
        {
            var kpis = _context.KPIs
                .Include(k => k.Department);

            return View(await kpis.ToListAsync());
        }

        // GET: KPIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kPI = await _context.KPIs
                .Include(k => k.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kPI == null)
            {
                return NotFound();
            }

            return View(kPI);
        }

        // GET: KPIs/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: KPIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,MaxScore,DepartmentId")] KPI kPI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kPI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", kPI.DepartmentId);
            return View(kPI);
        }

        // GET: KPIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kPI = await _context.KPIs.FindAsync(id);
            if (kPI == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", kPI.DepartmentId);
            return View(kPI);
        }

        // POST: KPIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,MaxScore,DepartmentId")] KPI kPI)
        {
            if (id != kPI.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kPI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KPIExists(kPI.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", kPI.DepartmentId);
            return View(kPI);
        }

        // GET: KPIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kPI = await _context.KPIs
                .Include(k => k.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kPI == null)
            {
                return NotFound();
            }

            return View(kPI);
        }

        // POST: KPIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kPI = await _context.KPIs.FindAsync(id);
            if (kPI != null)
            {
                _context.KPIs.Remove(kPI);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KPIExists(int id)
        {
            return _context.KPIs.Any(e => e.Id == id);
        }
    }
}
