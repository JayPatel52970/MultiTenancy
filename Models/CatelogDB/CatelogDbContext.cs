using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using MultiTenancyAngular.Models.CatelogDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public class CatelogDbContext : DbContext
    {
        public CatelogDbContext(DbContextOptions<CatelogDbContext> options):base(options)
        {
             
        }

        public DbSet<Tenant> tenants { get; set; }
        public DbSet<Server> servers{ get; set; }
        public DbSet<ElasticPool> elasticPools { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
