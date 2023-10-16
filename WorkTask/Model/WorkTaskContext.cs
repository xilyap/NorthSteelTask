using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkTask.Model;

public partial class WorkTaskContext : DbContext
{
    public WorkTaskContext()
    {
    }

    public WorkTaskContext(DbContextOptions<WorkTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SupplyGood> SupplyGoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WorkTask;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Good__3214EC070B890782");

            entity.ToTable("Good");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Provider).WithMany(p => p.Goods)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Good__ProviderId__5EBF139D");
            entity.HasData(
               new Good { Id = 1, Name = "Семечки подсолнечные жареные", ProviderId = 2 },
               new Good { Id = 2, Name = "Семечки подсолнечные", ProviderId = 2 },
               new Good { Id = 3, Name = "Семечки тыквенные жареные", ProviderId = 2 },
               new Good { Id = 4, Name = "Семечки тыквенные", ProviderId = 2 },
               new Good { Id = 6, Name = "Помидоры Абхазия", ProviderId = 1 },
               new Good { Id = 7, Name = "Помидоры Грузия", ProviderId = 1 },
               new Good { Id = 8, Name = "Помидоры Астрахань", ProviderId = 1 },
               new Good { Id = 9, Name = "Помидоры Башкортостан", ProviderId = 1 }
               );
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provider__3214EC07DF84B1FD");

            entity.ToTable("Provider");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.HasData(
                new Provider { Id = 1, Name = "ЗАО \"Лучшие помидоры\"" },
                new Provider { Id = 2, Name = "АО \"Лучшие семечки\"" }
                );
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supply__3214EC0742610B3C");

            entity.ToTable("Supply");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Provider).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Supply__Provider__619B8048");
        });

        modelBuilder.Entity<SupplyGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SupplyGo__3214EC078131CADC");

            entity.ToTable("SupplyGood");

            entity.HasOne(d => d.Good).WithMany(p => p.SupplyGoods)
                .HasForeignKey(d => d.GoodId)
                .HasConstraintName("FK__SupplyGoo__GoodI__656C112C");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyGoods)
                .HasForeignKey(d => d.SupplyId)
                .HasConstraintName("FK__SupplyGoo__Suppl__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
