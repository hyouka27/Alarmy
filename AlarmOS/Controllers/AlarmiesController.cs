using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlarmOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using System.Data.SqlClient;

namespace AlarmOS.Controllers
{
    //[Authorize]
    public class AlarmiesController : Controller
    {
        private readonly AlarmOSContext _context;

        public AlarmiesController(AlarmOSContext context)
        {
            _context = context;
        }
        public IActionResult No()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Stat()
        {
            return View(await _context.Alarmy.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "Z [HttpPost]Index: szukaj na " + searchString;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Alarmy
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: Alarmies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alarmy = await _context.Alarmy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alarmy == null)
            {
                return NotFound();
            }

            return View(alarmy);
        }

        // GET: Alarmies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alarmies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Employer,ReleaseDate,About,Level,Level2,UseId")] Alarmy alarmy)
        {
            switch (alarmy.Level)
            {
                case 1:
                    alarmy.Level2 = "Niski";
                    break;
                case 2:
                    alarmy.Level2 = "Średni";
                    break;
                
                case 3:
                    if (User.IsInRole("Emp3"))
                    {
                        alarmy.Level2 = "Wysoki";
                    }
                    else
                    {
                        return RedirectToAction(nameof(No));
                    }
                    break; 
            }
            string Userid = User.Identity.Name;
            alarmy.UseId = Userid;
            if (ModelState.IsValid)
            {
                _context.Add(alarmy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alarmy);
        }

        // GET: Alarmies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             
            if (id == null)
            {
                return NotFound();
            }

            var alarmy = await _context.Alarmy.FindAsync(id);
            if (alarmy == null)
            {
                return NotFound();
            }
            return View(alarmy);
        }

        // POST: Alarmies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Employer,ReleaseDate,About,Level,Level2")] Alarmy alarmy)
        {
            if (id != alarmy.Id)
            {
                return NotFound();
            }
            switch (alarmy.Level)
            {
                case 1:
                    alarmy.Level2 = "Niski";
                    break;
                case 2:
                    alarmy.Level2 = "Średni";
                    break;
                case 3:
                    if (User.IsInRole("Emp3"))
                    {
                        alarmy.Level2 = "Wysoki";
                    }
                    else
                    {
                        return RedirectToAction(nameof(No));
                    }
                    break;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alarmy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlarmyExists(alarmy.Id))
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
            return View(alarmy);
        }

        [Authorize(Roles = "Admin,Emp3")]
        // GET: Alarmies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alarmy = await _context.Alarmy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alarmy == null)
            {
                return NotFound();
            }

            return View(alarmy);
        }

        [Authorize(Roles = "Admin,Emp3")]
        // POST: Alarmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alarmy = await _context.Alarmy.FindAsync(id);
            _context.Alarmy.Remove(alarmy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlarmyExists(int id)
        {
            return _context.Alarmy.Any(e => e.Id == id);
        }
    }
}
