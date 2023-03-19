using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Les_Birds.Data;
using Les_Birds.Models;

namespace Les_Birds.Areas.Pages
{
    public class EditModel : PageModel
    {
        private readonly Les_Birds.Data.ApplicationDbContext _context;

        public EditModel(Les_Birds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bird == null)
            {
                return NotFound();
            }

            var bird =  await _context.Bird.FirstOrDefaultAsync(m => m.Id == id);
            if (bird == null)
            {
                return NotFound();
            }
            Bird = bird;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bird).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdExists(Bird.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BirdExists(int id)
        {
          return (_context.Bird?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
