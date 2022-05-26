using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.MyTasks
{
    public class DetailsModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public DetailsModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyTask MyTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyTask = await _context.MyTasks
                .Include(m => m.Category)
                .Include(m => m.Status)
                .Include(m => m.User).FirstOrDefaultAsync(m => m.MyTaskId == id);

            if (MyTask == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/Page403");
        }
    }
}
