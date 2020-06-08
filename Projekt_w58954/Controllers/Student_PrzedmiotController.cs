using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_w58954;

namespace Projekt_w58954.Controllers
{
    public class Student_PrzedmiotController : Controller
    {
        private readonly Context _context;

        public Student_PrzedmiotController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Student_Przedmiots.Include(s => s.Przedmiot).Include(s => s.Student);
            return View(await context.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Przedmiot = await _context.Student_Przedmiots
                .Include(s => s.Przedmiot)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student_Przedmiot == null)
            {
                return NotFound();
            }

            return View(student_Przedmiot);
        }

        public IActionResult Create(int? aid)
        {
            ViewData["Przedmiot_id"] = new SelectList(_context.Przedmiots, "Id", "Nazwa_przedmiotu");
            ViewData["Student_id"] = new SelectList(_context.Students, "Id", "Imie", aid == null ? 1 : aid);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Student_id,Przedmiot_id")] Student_Przedmiot student_Przedmiot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Przedmiot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Przedmiot_id"] = new SelectList(_context.Przedmiots, "Id", "Id", student_Przedmiot.Przedmiot_id);
            ViewData["Student_id"] = new SelectList(_context.Students, "Id", "Id", student_Przedmiot.Student_id);


            return View(student_Przedmiot);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Przedmiot = await _context.Student_Przedmiots.FindAsync(id);
            if (student_Przedmiot == null)
            {
                return NotFound();
            }
            ViewData["Przedmiot_id"] = new SelectList(_context.Przedmiots, "Id", "Id", student_Przedmiot.Przedmiot_id);
            ViewData["Student_id"] = new SelectList(_context.Students, "Id", "Id", student_Przedmiot.Student_id);
            return View(student_Przedmiot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Student_id,Przedmiot_id")] Student_Przedmiot student_Przedmiot)
        {
            if (id != student_Przedmiot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Przedmiot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_PrzedmiotExists(student_Przedmiot.Id))
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
            ViewData["Przedmiot_id"] = new SelectList(_context.Przedmiots, "Id", "Id", student_Przedmiot.Przedmiot_id);
            ViewData["Student_id"] = new SelectList(_context.Students, "Id", "Id", student_Przedmiot.Student_id);
            return View(student_Przedmiot);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Przedmiot = await _context.Student_Przedmiots
                .Include(s => s.Przedmiot)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student_Przedmiot == null)
            {
                return NotFound();
            }

            return View(student_Przedmiot);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Przedmiot = await _context.Student_Przedmiots.FindAsync(id);
            _context.Student_Przedmiots.Remove(student_Przedmiot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_PrzedmiotExists(int id)
        {
            return _context.Student_Przedmiots.Any(e => e.Id == id);
        }
    }
}
