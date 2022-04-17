#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pog.Data;
using Pog.Models;

namespace Pog.Controllers
{
    [Authorize]
    public class TopicDueDatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicDueDatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TopicDueDates
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopicDueDates.ToListAsync());
        }

        // GET: TopicDueDates/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicDueDate = await _context.TopicDueDates.Include(m=>m.TopicList)               
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicDueDate == null)
            {
                return NotFound();
            }
            ViewData["Topics"] = await _context.Topics.Include(t => t.User).Include(t=>t.Category).Include(t=>t.TopicDueDate).Where(t => t.TopicDueDateId == id).ToListAsync();
            return View(topicDueDate);
        }


        // GET: TopicDueDates/Create
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopicDueDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreateDate,DueDate,FinalDate")] TopicDueDate topicDueDate)
        {
            if (ModelState.IsValid)
            {
               
                
                    topicDueDate.CreateDate = DateTime.Now;
                    _context.Add(topicDueDate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
               
            }
            return View(topicDueDate);
        }

        // GET: TopicDueDates/Edit/5
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicDueDate = await _context.TopicDueDates.FindAsync(id);
            if (topicDueDate == null)
            {
                return NotFound();
            }
            return View(topicDueDate);
        }

        // POST: TopicDueDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DueDate,FinalDate")] TopicDueDate topicDueDate)
        {
            if (id != topicDueDate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {               
                    _context.Update(topicDueDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicDueDateExists(topicDueDate.Id))
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
            return View(topicDueDate);
        }

        // GET: TopicDueDates/Delete/5
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            var topicDueDate = await _context.TopicDueDates.FindAsync(id);
            _context.TopicDueDates.Remove(topicDueDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

           
        }

        // POST: TopicDueDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicDueDate = await _context.TopicDueDates.FindAsync(id);
            _context.TopicDueDates.Remove(topicDueDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicDueDateExists(int id)
        {
            return _context.TopicDueDates.Any(e => e.Id == id);
        }
    }
}
