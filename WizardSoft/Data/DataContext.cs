using Microsoft.EntityFrameworkCore;

namespace WizardSoft.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<Dir> Dirs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
