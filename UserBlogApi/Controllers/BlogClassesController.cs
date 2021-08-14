using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserBlogApi.Data;
using UserBlogApi.Model;

namespace UserBlogApi.Controllers
{
    public class BlogClassesController : Controller
    {
        private readonly UserBlogApiContext _context;

        public BlogClassesController(UserBlogApiContext context)
        {
            _context = context;
        }

        // GET: BlogClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogClass.ToListAsync());
        }

        // GET: BlogClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogClass = await _context.BlogClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogClass == null)
            {
                return NotFound();
            }

            return View(blogClass);
        }

        // GET: BlogClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Title,Content,Images,Date,Likes")] BlogClass blogClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogClass);
        }

        // GET: BlogClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogClass = await _context.BlogClass.FindAsync(id);
            if (blogClass == null)
            {
                return NotFound();
            }
            return View(blogClass);
        }

        // POST: BlogClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Title,Content,Images,Date,Likes")] BlogClass blogClass)
        {
            if (id != blogClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogClassExists(blogClass.Id))
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
            return View(blogClass);
        }

        // GET: BlogClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogClass = await _context.BlogClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogClass == null)
            {
                return NotFound();
            }

            return View(blogClass);
        }

        // POST: BlogClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogClass = await _context.BlogClass.FindAsync(id);
            _context.BlogClass.Remove(blogClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogClassExists(int id)
        {
            return _context.BlogClass.Any(e => e.Id == id);
        }
    }
}
