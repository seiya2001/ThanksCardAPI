using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ThanksCard> ThanksCards{ get; set; }
        public DbSet<ThanksCardAPI.Models.Tag> Tag { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QandA_Kategory> QandA_Kategorys { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}
