using Microsoft.EntityFrameworkCore;
using REPO_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }       
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }      
        public DbSet<Role> Roles { get; set; }

    }
}
