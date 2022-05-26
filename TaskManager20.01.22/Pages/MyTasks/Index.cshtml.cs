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
    public class IndexModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public IndexModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MyTask> MyTask { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MyTask = await _context.MyTasks
                .Include(m => m.Category)
                .Include(m => m.Status)
                .Include(m => m.User)
                .Where(m =>m.User.UserName == User.Identity.Name)  //* фильтр
                .ToListAsync();
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/Page403");
        }
    }
}
