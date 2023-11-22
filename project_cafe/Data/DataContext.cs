using Microsoft.EntityFrameworkCore;

namespace project_cafe.Data
{
    internal class DataContext:DbContext
    {
        public DbSet<Good> Goods {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<MonthlyAction> MonthlyActions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cafe;Trusted_Connection=True");
        }
    }
}
