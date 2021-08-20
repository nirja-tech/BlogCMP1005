using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog1005_Api.Data;
using Blog1005_Api.Model;

namespace Blog1005_Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]/[action]")]
    public class BlogsApisController : Controller
    {
        private readonly Blog1005_ApiContext _context;

        public BlogsApisController(Blog1005_ApiContext context)
        {
            _context = context;
        }
       
        // GET: BlogsApis
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.BlogsApi.ToListAsync());
        }*/

        // GET: BlogsApis/Details/5

        
        [HttpGet]
        public async Task<BlogsApi> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
            }

            var blogsApi = await _context.BlogsApi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogsApi == null)
            {
               // return NotFound();
            }

            return (blogsApi);
        }
       


        [HttpGet]
        public async Task<ActionResult<BlogsApi>> AddNewBlog(String title, String likes, String username, String content, String images, DateTime datew)
        {
            Response.Headers.Add("New-Data", "*");
            var NewUser = new BlogsApi();
            NewUser.Title = title;
            NewUser.Images = images;
            NewUser.Likes = likes;
            NewUser.UserName = username;
            NewUser.Content = content;
            NewUser.Date = datew;


            _context.BlogsApi.Remove(NewUser);
            await _context.SaveChangesAsync();
            return NoContent();
        }

       /* // GET: BlogsApis/Create
        public IActionResult Create()
        {
            return View();
        }
      */
        
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<BlogsApi> Create([Bind("Id,UserName,Title,Content,Images,Date,Likes")] BlogsApi blogsApi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogsApi);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
            }
            return (blogsApi);
        }

     /*   // GET: BlogsApis/Edit/5
        public async Task<BlogsApi> Edit(int? id)
        {
            if (id == null)
            {
               return NotFound()
            }

            var blogsApi = await _context.BlogsApi.FindAsync(id);
            if (blogsApi == null)
            {
                //return NotFound();
            }
           // return View(blogsApi);
        }
     */
       

        
     /*   [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Title,Content,Images,Date,Likes")] BlogsApi blogsApi)
        {
            if (id != blogsApi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogsApi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogsApiExists(blogsApi.Id))
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
            return View(blogsApi);
        }
     */
     /*
        // GET: BlogsApis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogsApi = await _context.BlogsApi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogsApi == null)
            {
                return NotFound();
            }

            return View(blogsApi);
        }

        // POST: BlogsApis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogsApi = await _context.BlogsApi.FindAsync(id);
            _context.BlogsApi.Remove(blogsApi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       

        private bool BlogsApiExists(int id)
        {
            return _context.BlogsApi.Any(e => e.Id == id);
        }
     */

    }
}
