using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KeukenhofV2.Models;

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
        public DbSet<ToegankelijkheidContent> ToegankelijkheidContent { get; set; }
    }
}
