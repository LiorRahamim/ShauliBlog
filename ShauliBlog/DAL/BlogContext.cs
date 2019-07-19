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

        // Prevents pluralized table naming (i.e, prevent the table name to be 'Fans')
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}