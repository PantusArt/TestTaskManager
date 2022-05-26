using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager20._01._22.Data;
using TaskManager20._01._22.Models;

namespace TaskManager20._01._22.Pages.Statuses
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
            if (User.Identity.IsAuthenticated && User.Identity.Name == "admin123@gmail.com")

                return Page();
            else
                return RedirectToPage("/Access/Page403");
        }

        [BindProperty]
        public Status Status { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Statuses.Add(Status);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
