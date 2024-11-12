using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Model;

namespace PrimeiraApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=teste;Trusted_Connection=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
