using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;

namespace Application.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly Context _context;

        public EditModel(Context context) => _context = context;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id)) { return NotFound(); }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}