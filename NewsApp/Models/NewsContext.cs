using Microsoft.EntityFrameworkCore;

namespace NewsApp.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<ContactUS> ContactUs { get; set; }

    }

}
