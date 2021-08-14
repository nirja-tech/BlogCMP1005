using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Data;
using BlogAPI.Model;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApisController : ControllerBase
    {
        private readonly BlogAPIContext _context;

        public BlogApisController(BlogAPIContext context)
        {
            _context = context;
        }

        // GET: api/BlogApis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogApi>>> GetBlogApi()
        {
            return await _context.BlogApi.ToListAsync();
        }

        // GET: api/BlogApis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogApi>> GetBlogApi(int id)
        {
            var blogApi = await _context.BlogApi.FindAsync(id);

            if (blogApi == null)
            {
                return NotFound();
            }

            return blogApi;
        }

        // PUT: api/BlogApis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogApi(int id, BlogApi blogApi)
        {
            if (id != blogApi.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogApi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogApiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogApis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogApi>> PostBlogApi(BlogApi blogApi)
        {
            _context.BlogApi.Add(blogApi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogApi", new { id = blogApi.Id }, blogApi);
        }

        // DELETE: api/BlogApis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogApi(int id)
        {
            var blogApi = await _context.BlogApi.FindAsync(id);
            if (blogApi == null)
            {
                return NotFound();
            }

            _context.BlogApi.Remove(blogApi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogApiExists(int id)
        {
            return _context.BlogApi.Any(e => e.Id == id);
        }
    }
}
