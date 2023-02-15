using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());

            if (context is null || context.Movies is null)
            {
                throw new ArgumentNullException("Null Context");
            }

            if (context.Movies.Any()) { return; }

            context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Quando Herry conheceu Silly",
                        ReleaseDate = DateTime.Parse("12/02/1989"),
                        Genre = "Comédia romântica",
                        Price = 17.99M
                    },

                    new Movie
                    {
                        Title = "Os caças-fantasmas ",
                        ReleaseDate = DateTime.Parse("13/03/1984"),
                        Genre = "Comédia",
                        Price = 18.99M
                    },

                    new Movie
                    {
                        Title = "Os caças-fantasmas 2",
                        ReleaseDate = DateTime.Parse("23/02/1986"),
                        Genre = "Comédia",
                        Price = 19.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("15/04/1959"),
                        Genre = "Velho Oeste",
                        Price = 13.99M
                    }
                );

            context.SaveChanges();
        }
    }
}
