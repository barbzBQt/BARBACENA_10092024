using BARBACENA_10092024.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BARBACENA_10092024.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}