using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTeamTaskManagement.Data;
using ProjectTeamTaskManagement.Models;

namespace ProjectTeamTaskManagement.Controllers
{
    public class TaskAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.TaskAllocations.Include(t => t.Tasks).Include(e => e.Employees);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAllocations = await _context.TaskAllocations
                .Include(t => t.Tasks).Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.TaskAllocationId == id);

            if (taskAllocations == null)
            {
                return NotFound();
            }

            return View(taskAllocations);
        }

        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskAllocations taskAllocations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskAllocations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", taskAllocations.TaskId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", taskAllocations.EmployeeId);

            return View(taskAllocations);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAllocations = await _context.TaskAllocations.FindAsync(id);
            if (taskAllocations == null)
            {
                return NotFound();
            }

            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", taskAllocations.TaskId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", taskAllocations.EmployeeId);

            return View(taskAllocations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskAllocationId,AllocationDate,TaskId,EmployeeId,CompletionDate")] TaskAllocations taskAllocations)
        {
            if (id != taskAllocations.TaskAllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskAllocations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskAllocationsExists(taskAllocations.TaskAllocationId))
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

            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", taskAllocations.TaskId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", taskAllocations.EmployeeId);

            return View(taskAllocations);
        }

        // GET: TaskAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAllocations = await _context.TaskAllocations
                .FirstOrDefaultAsync(m => m.TaskAllocationId == id);
            if (taskAllocations == null)
            {
                return NotFound();
            }

            return View(taskAllocations);
        }

        // POST: TaskAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskAllocations = await _context.TaskAllocations.FindAsync(id);
            _context.TaskAllocations.Remove(taskAllocations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskAllocationsExists(int id)
        {
            return _context.TaskAllocations.Any(e => e.TaskAllocationId == id);
        }
    }
}
