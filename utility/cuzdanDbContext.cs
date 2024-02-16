using cdeneme.Models;
using Microsoft.EntityFrameworkCore;


namespace cdeneme.utility
{
    public class cuzdanDbContext : DbContext
    {

        public cuzdanDbContext(DbContextOptions<cuzdanDbContext> options) : base(options) { }

        public DbSet<Cuzdana> cuzdan { get; set; }


    }
}
