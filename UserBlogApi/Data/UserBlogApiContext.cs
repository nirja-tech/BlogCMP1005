using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserBlogApi.Model;

namespace UserBlogApi.Data
{
    public class UserBlogApiContext : DbContext
    {
        public UserBlogApiContext (DbContextOptions<UserBlogApiContext> options)
            : base(options)
        {
        }

        public DbSet<UserBlogApi.Model.BlogClass> BlogClass { get; set; }
    }
}
