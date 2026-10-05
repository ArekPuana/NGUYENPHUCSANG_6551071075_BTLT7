using Microsoft.EntityFrameworkCore;

namespace QuanLyTheLoaiSach.Models;

public partial class TriThucBooksContext : DbContext
{
    public TriThucBooksContext()
    {
    }

    public TriThucBooksContext(
        DbContextOptions<TriThucBooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-4GRER6D\SQLEXPRESS;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaTl);

            entity.ToTable("TheLoaiSach");

            entity.HasIndex(e => e.TenTheLoai)
                .IsUnique();

            entity.Property(e => e.MaTl)
                .HasColumnName("MaTL");

            entity.Property(e => e.TenTheLoai)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.MoTa)
                .HasMaxLength(255);

            entity.Property(e => e.SoLuongSach)
                .HasDefaultValue(0);

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}