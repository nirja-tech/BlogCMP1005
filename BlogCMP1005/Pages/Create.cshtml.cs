using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogCMP1005.Models;
using System.IO;

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
        public async Task<IActionResult> OnPostAsync(IFormFile formFile)
        {
            if (formFile != null)
            {

                if (formFile.Length > 0)
                {
                    var ImageName = Path.GetFileName(formFile.FileName);
                    var ImageExtension = Path.GetExtension(ImageName);
                    //var UserName = string.Concat(System.Convert.ToString(System.Guid.NewGuid()), ImageExtension);
                    var objFiles = new Blog()
                    {

                        Images = ImageName



                    };

                    using (var target = new MemoryStream())
                    {


                        formFile.CopyTo(target);



                    }

                    _context.Blog.Add(objFiles);




                }

            }


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
