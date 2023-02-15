using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;

namespace Application.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly Context _context;

        public DeleteModel(Context context) => _context = context;


        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null || _context.Movies is null) { return NotFound(); }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is null) { return NotFound(); } 
           
            Movie = movie;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id is null || _context.Movies is null) { return NotFound(); }

            var movie = await _context.Movies.FindAsync(id);

            if (movie is not null)
            {
                Movie = movie;
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}