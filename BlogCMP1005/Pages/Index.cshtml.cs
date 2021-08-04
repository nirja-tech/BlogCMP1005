using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogCMP1005.Data;
using BlogCMP1005.Models;

namespace BlogCMP1005.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BlogCMP1005.Data.ApplicationDbContext _context;

        public IndexModel(BlogCMP1005.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; }

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog.ToListAsync();
        }
    }
}
