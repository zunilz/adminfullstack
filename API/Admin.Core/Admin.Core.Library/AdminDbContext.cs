using Admin.Core.Library.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Core.Library
{
    public class AdminDbContext: DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products{ get; set; } 
        public DbSet<ProductKeywords> ProductKeywords{ get; set; }
        public DbSet<KeywordTags> KeywordTags{ get; set; }

    }
}
