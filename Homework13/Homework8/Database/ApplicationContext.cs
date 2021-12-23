using Homework8.DbModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ExpressionModel> Expressions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}