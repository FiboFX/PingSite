using Microsoft.EntityFrameworkCore;
using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.EF
{
    public class PingSiteContext : DbContext
    {
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public PingSiteContext(DbContextOptions<PingSiteContext> options) : base(options) { }
    }
}
