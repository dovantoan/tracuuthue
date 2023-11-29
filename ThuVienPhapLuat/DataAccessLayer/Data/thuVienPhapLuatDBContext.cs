using System;
using System.Collections.Generic;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public partial class thuVienPhapLuatDBContext : DbContext
{
    public thuVienPhapLuatDBContext()
    {
    }

    public thuVienPhapLuatDBContext(DbContextOptions<thuVienPhapLuatDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoQuanBanHanh> CoQuanBanHanhs { get; set; }

    public virtual DbSet<LinhVuc> LinhVucs { get; set; }

    public virtual DbSet<ThongTinVanBan> ThongTinVanBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HCM-KCN-441\\MSSQLSERVER2014;Database=ThuVienPhapLuat;Trusted_Connection=True;User ID=sa;Password=sql@2014;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoQuanBanHanh>(entity =>
        {
            entity.ToTable("CoQuanBanHanh");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ten).HasMaxLength(1000);
        });

        modelBuilder.Entity<LinhVuc>(entity =>
        {
            entity.ToTable("LinhVuc");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ten).HasMaxLength(1000);
        });

        modelBuilder.Entity<ThongTinVanBan>(entity =>
        {
            entity.ToTable("ThongTinVanBan");

            entity.Property(e => e.Detailt).HasMaxLength(1000);
            entity.Property(e => e.Linkdownload).HasMaxLength(2000);
            entity.Property(e => e.NgayBanHanh).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoKyHieu).HasMaxLength(250);
            entity.Property(e => e.TrichYeu).HasMaxLength(2000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
