using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.Data
{
    public class EduManagerContext : DbContext
    {
        
        private const string ConnectionString =
            @"Server=Nhat-Hoang\SQLEXPRESS;Database=EduManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MONHOC");
                entity.HasKey(e => e.MaMonHoc);

                entity.Property(e => e.MaMonHoc)
                      .HasColumnType("nvarchar(10)")
                      .HasMaxLength(10)
                      .IsRequired();

                entity.Property(e => e.TenMonHoc)
                      .HasColumnType("nvarchar(100)")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.SoTinChi).IsRequired();

                entity.Property(e => e.TrangThai)
                      .HasDefaultValue(true);
            });
        }
    }
}
