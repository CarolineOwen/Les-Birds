using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Les_Birds.Data;
using Les_Birds.Models;
using Les_Birds.Services;
using System.Drawing;

namespace Les_Birds.Areas.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageService imageService;

        public CreateModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            this.imageService = imageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid)
          //  {
          //      return Page();
          //  }
         // var emptyBird= new Bird();

          
            if(null != Bird.Image)
            {
                await imageService.UploadAsync(Bird.Image);
            }
           
            _context.Bird.Add(Bird);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
