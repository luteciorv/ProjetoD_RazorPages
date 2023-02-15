using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Data;
using Application.Models;

namespace Application.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Context _context;

        public CreateModel(Context context) => _context = context;

        public IActionResult OnGet() { return Page(); }

        [BindProperty]
        public Movie Movie { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}