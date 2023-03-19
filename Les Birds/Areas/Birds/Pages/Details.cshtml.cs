using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Les_Birds.Data;
using Les_Birds.Models;

namespace Les_Birds.Areas.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Les_Birds.Data.ApplicationDbContext _context;

        public DetailsModel(Les_Birds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Bird Bird { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bird == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird.FirstOrDefaultAsync(m => m.Id == id);
            if (bird == null)
            {
                return NotFound();
            }
            else 
            {
                Bird = bird;
            }
            return Page();
        }
    }
}
