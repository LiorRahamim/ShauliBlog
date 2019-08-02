using System.Data.Entity;
using ShauliBlog.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShauliBlog.DAL
{
      public class BlogContext : DbContext
    {

        public BlogContext() : base("BlogContext")
        {
        }

        public DbSet<Fan> Fans { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // Prevents pluralized table naming (i.e, prevent the table name to be 'Fans')
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ShauliBlog.Models.LoginModel> LoginModels { get; set; }

        public System.Data.Entity.DbSet<ShauliBlog.Models.RegisterModel> RegisterModels { get; set; }
    }

}