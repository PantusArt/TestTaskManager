using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public IndexModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
            if (User.Identity.IsAuthenticated)
                return Page();
            else
            return RedirectToPage("/Access/Page403");
        }
    }
}
