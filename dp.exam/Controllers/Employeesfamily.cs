using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dp.exam.Infrastructure.DAL;
using dp.exam.Models.DbEntity;

namespace dp.exam.Controllers
{
    public class Employeesfamily : Controller
    {
        private readonly ApplicationDBcontext _context;

        public Employeesfamily(ApplicationDBcontext context)
        {
            _context = context;
        }

        // GET: Employeesfamily
        public async Task<IActionResult> Index()
        {
            var applicationDBcontext = _context.EmployeeFamilies.Include(e => e.Employee);
            return View(await applicationDBcontext.ToListAsync());
        }

        // GET: Employeesfamily/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFamily = await _context.EmployeeFamilies
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeFamily == null)
            {
                return NotFound();
            }

            return View(employeeFamily);
        }

        // GET: Employeesfamily/Create
        public IActionResult Create()
        {
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "Id", "Address1");
            return View();
        }

        // POST: Employeesfamily/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FristName,Surname,Relationship,FkEmployeeId,Id")] EmployeeFamily employeeFamily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeFamily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "Id", "Address1", employeeFamily.FkEmployeeId);
            return View(employeeFamily);
        }

        // GET: Employeesfamily/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFamily = await _context.EmployeeFamilies.FindAsync(id);
            if (employeeFamily == null)
            {
                return NotFound();
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "Id", "Address1", employeeFamily.FkEmployeeId);
            return View(employeeFamily);
        }

        // POST: Employeesfamily/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FristName,Surname,Relationship,FkEmployeeId,Id")] EmployeeFamily employeeFamily)
        {
            if (id != employeeFamily.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeFamily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeFamilyExists(employeeFamily.Id))
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
            ViewData["FkEmployeeId"] = new SelectList(_context.Employees, "Id", "Address1", employeeFamily.FkEmployeeId);
            return View(employeeFamily);
        }

        // GET: Employeesfamily/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFamily = await _context.EmployeeFamilies
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeFamily == null)
            {
                return NotFound();
            }

            return View(employeeFamily);
        }

        // POST: Employeesfamily/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeFamily = await _context.EmployeeFamilies.FindAsync(id);
            _context.EmployeeFamilies.Remove(employeeFamily);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeFamilyExists(int id)
        {
            return _context.EmployeeFamilies.Any(e => e.Id == id);
        }
    }
}
