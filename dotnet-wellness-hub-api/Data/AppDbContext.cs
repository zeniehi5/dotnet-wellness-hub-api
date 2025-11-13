using dotnet_wellness_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wellness_hub_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VideoCategory> VideoCategories { get; set; }
    }
}

