using Microsoft.EntityFrameworkCore;
using InventorySystem.Entities.Entities;
using System.Threading.Tasks;
using System;

namespace InventorySystem.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        private readonly string _connectionString = string.Empty;
        public SqlServerContext()
        {
            _connectionString = @"Data Source = LTUSPE-L0004\SQLEXPRESS; Initial Catalog = InventorySystem; Integrated Security = true";
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>().HasKey(c => new { c.IdArticulo });
            modelBuilder.Entity<Articulo>().Property(c => c.IdArticulo).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Movimiento>().HasKey(c => new { c.IdMovimiento });
            modelBuilder.Entity<Movimiento>().Property(c => c.IdMovimiento).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
