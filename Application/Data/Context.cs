using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace Application.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; } = default!;
    }
}