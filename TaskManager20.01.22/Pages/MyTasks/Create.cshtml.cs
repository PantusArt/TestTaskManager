using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.MyTasks
{
    public class CreateModel : PageModel
    {
        private readonly TaskManager20._01._22.Data.ApplicationDbContext _context;

        public CreateModel(TaskManager20._01._22.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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

        [BindProperty]
        public MyTask MyTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyTasks.Add(MyTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
