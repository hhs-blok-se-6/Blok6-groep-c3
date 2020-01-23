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
        public DbSet<VeelgesteldeVragen> VeelgesteldeVragen { get; set; }
        public DbSet<HomeContent> HomeContent { get; set; }
        public DbSet<EvenementenContent> EvenementenContent { get; set; }
        public DbSet<Evenementen> Evenementen { get; set; }
        public DbSet<EvenementenPagina> EvenementenPagina { get; set; }
        public DbSet<ToegankelijkheidContent> ToegankelijkheidContent { get; set; }
        public DbSet<ContactContent> ContactContent { get; set; }
        public DbSet<FeaturedContent> FeaturedContent { get; set; }
        public DbSet<CardContent> CardContent { get; set; }
        public DbSet<EditPagesModel> EditPagesModel { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<BereikbaarheidContent> BereikbaarheidContent { get; set; }
        public DbSet<ParkContent> ParkContent { get; set; }
        public DbSet<PrivacyContent> PrivacyContent { get; set; }
        public DbSet<PraktischContent> PraktischContent { get; set; }
        public DbSet<CTAButton> CTAButtons { get; set; }
        public DbSet<KeukenhofV2.Models.ZoekResultaten> ZoekResultaten { get; set; }

        
    }
}
