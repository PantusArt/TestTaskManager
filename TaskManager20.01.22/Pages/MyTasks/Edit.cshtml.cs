using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.MyTasks
{
    public class EditModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public EditModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            var currentUser = _context.ApplicationUsers
               .Where(u => u.UserName == User.Identity.Name)
               .FirstOrDefault();
            List<ApplicationUser> currentUserBox = new() { currentUser };

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            ViewData["UserId"] = new SelectList(currentUserBox, "Id", "UserName");
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/Page403");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MyTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(MyTask.MyTaskId))
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

        private bool MyTaskExists(int id)
        {
            return _context.MyTasks.Any(e => e.MyTaskId == id);
        }
    }
}
