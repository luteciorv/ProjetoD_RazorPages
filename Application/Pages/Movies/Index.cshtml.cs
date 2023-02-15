using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Application.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public IList<Movie> Movies { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? MovieTitle { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        private readonly Context _context;


        public IndexModel(Context context) => _context = context;

        public async Task OnGetAsync()
        {
            IQueryable<Movie> movies = _context.Movies;
            IQueryable<string> genres = _context.Movies.OrderBy(m => m.Genre).Select(m => m.Genre).Distinct();


            if (!string.IsNullOrEmpty(MovieTitle))
                movies = movies.Where(m => m.Title.Contains(MovieTitle));

            if (!string.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(m => m.Genre == MovieGenre);
            

            Movies = await movies.ToListAsync();
            Genres = new SelectList(await genres.ToListAsync());
        }
    }
}