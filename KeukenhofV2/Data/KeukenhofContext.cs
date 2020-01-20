using KeukenhofV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeukenhofV2.Data
{
    public class KeukenhofContext : IdentityDbContext
    {
        public KeukenhofContext(DbContextOptions<KeukenhofContext> options) : base(options)
        {

        }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<HomeContent> HomeContent { get; set; }
        public DbSet<EvenementenContent> EvenementenContent { get; set; }
        public DbSet<Evenementen> Evenementen { get; set; }
        public DbSet<FeaturedContent> FeaturedContent { get; set; }
        public DbSet<CardContent> CardContent { get; set; }
    }
}
