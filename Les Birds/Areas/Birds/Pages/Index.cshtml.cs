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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bird != null)
            {
                Bird = await _context.Bird.Include(f=>f.Image).ToListAsync();
            }
        }
    }
}
