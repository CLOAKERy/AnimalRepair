using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Animal_Repair;

namespace Animal_Repair.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalRepairContext _context;

        public AnimalController(AnimalRepairContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var animalRepairContext = _context.Animals.Include(a => a.IdGenderNavigation).Include(a => a.IdKindOfAnimalNavigation).Include(a => a.IdOrderNavigation);
            return View(await animalRepairContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.IdGenderNavigation)
                .Include(a => a.IdKindOfAnimalNavigation)
                .Include(a => a.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.KindOfGenders, "Id", "Gender");
            ViewData["IdKindOfAnimal"] = new SelectList(_context.KindOfAnimals, "Id", "Name");
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Date");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdKindOfAnimal,IdOrder,IdGender,DateOfBirth,Description,Picture")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.KindOfGenders, "Id", "Gender", animal.IdGender);
            ViewData["IdKindOfAnimal"] = new SelectList(_context.KindOfAnimals, "Id", "Name", animal.IdKindOfAnimal);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Date", animal.IdOrder);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.KindOfGenders, "Id", "Gender", animal.IdGender);
            ViewData["IdKindOfAnimal"] = new SelectList(_context.KindOfAnimals, "Id", "Name", animal.IdKindOfAnimal);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Date", animal.IdOrder);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdKindOfAnimal,IdOrder,IdGender,DateOfBirth,Description,Picture")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            ViewData["IdGender"] = new SelectList(_context.KindOfGenders, "Id", "Gender", animal.IdGender);
            ViewData["IdKindOfAnimal"] = new SelectList(_context.KindOfAnimals, "Id", "Name", animal.IdKindOfAnimal);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Date", animal.IdOrder);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.IdGenderNavigation)
                .Include(a => a.IdKindOfAnimalNavigation)
                .Include(a => a.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set 'AnimalRepairContext.Animals'  is null.");
            }
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
          return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
