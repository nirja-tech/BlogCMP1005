using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogCMP1005.Models;


namespace BlogCMP1005.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BlogCMP1005.Data.ApplicationDbContext _context;
       

        public CreateModel(BlogCMP1005.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blog.Add(Blog);
            await _context.SaveChangesAsync();

          

            return RedirectToPage("./Index");
        }
    }
}
