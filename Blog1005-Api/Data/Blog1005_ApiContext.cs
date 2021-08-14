using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog1005_Api.Model;

namespace Blog1005_Api.Data
{
    public class Blog1005_ApiContext : DbContext
    {
        public Blog1005_ApiContext (DbContextOptions<Blog1005_ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Blog1005_Api.Model.BlogsApi> BlogsApi { get; set; }
    }
}
