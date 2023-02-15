using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;

namespace Application.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;

        public IndexModel(Context context) => _context = context;

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies is not null)
            {
                Movie = await _context.Movies.ToListAsync();
            }
        }
    }
}