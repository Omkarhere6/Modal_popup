using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modal_popup.Models;

namespace Modal_popup.Controllers
{
    public class EmployeeTbsController : Controller
    {
        private readonly Employee_management_SystemContext _context;

        public EmployeeTbsController(Employee_management_SystemContext context)
        {
            _context = context;
        }

        // GET: EmployeeTbs
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeTb != null ? 
                          View(await _context.EmployeeTb.ToListAsync()) :
                          Problem("Entity set 'Employee_management_SystemContext.EmployeeTb'  is null.");
        }

        // GET: EmployeeTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeTb == null)
            {
                return NotFound();
            }

            var employeeTb = await _context.EmployeeTb
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeTb == null)
            {
                return NotFound();
            }

            return View(employeeTb);
        }

        // GET: EmployeeTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,EmpAge,EmpGender,EmpDepartment,EmpDesignation,EmpPno,EmpSalary")] EmployeeTb employeeTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTb);
        }

        // GET: EmployeeTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeTb == null)
            {
                return NotFound();
            }

            var employeeTb = await _context.EmployeeTb.FindAsync(id);
            if (employeeTb == null)
            {
                return NotFound();
            }
            return View(employeeTb);
        }

        // POST: EmployeeTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpName,EmpAge,EmpGender,EmpDepartment,EmpDesignation,EmpPno,EmpSalary")] EmployeeTb employeeTb)
        {
            if (id != employeeTb.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTbExists(employeeTb.EmpId))
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
            return View(employeeTb);
        }

        // GET: EmployeeTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeTb == null)
            {
                return NotFound();
            }

            var employeeTb = await _context.EmployeeTb
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeTb == null)
            {
                return NotFound();
            }

            return View(employeeTb);
        }

        // POST: EmployeeTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeTb == null)
            {
                return Problem("Entity set 'Employee_management_SystemContext.EmployeeTb'  is null.");
            }
            var employeeTb = await _context.EmployeeTb.FindAsync(id);
            if (employeeTb != null)
            {
                _context.EmployeeTb.Remove(employeeTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTbExists(int id)
        {
          return (_context.EmployeeTb?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
