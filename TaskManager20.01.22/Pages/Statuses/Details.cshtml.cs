using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.Statuses
{
    public class DetailsModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public DetailsModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Status Status { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Status = await _context.Statuses.FirstOrDefaultAsync(m => m.StatusId == id);

            if (Status == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
