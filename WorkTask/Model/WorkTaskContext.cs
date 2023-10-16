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
               new Good { Id = 5, Name = "Помидоры Абхазия", ProviderId = 1 },
               new Good { Id = 6, Name = "Помидоры Грузия", ProviderId = 1 },
               new Good { Id = 7, Name = "Помидоры Астрахань", ProviderId = 1 },
               new Good { Id = 8, Name = "Помидоры Башкортостан", ProviderId = 1 }
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
            entity.HasData(
                new Supply() { Date = DateTime.Now, Id = 1, ProviderId = 1, },
                new Supply() { Date = DateTime.Now.AddDays(-5), Id = 2, ProviderId = 2, },
                new Supply() { Date = DateTime.Now.AddDays(-7), Id = 3, ProviderId = 1, });
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
            entity.HasData(
                new SupplyGood() { Id = 1, GoodId = 8, SupplyId = 1, Weight = 5.5f, Price = 3300 },
                new SupplyGood() { Id = 2, GoodId = 7, SupplyId = 1, Weight = 6f, Price = 5900 },
                new SupplyGood() { Id = 3, GoodId = 1, SupplyId = 2, Weight = 215f, Price = 115000 },
                new SupplyGood() { Id = 4, GoodId = 2, SupplyId = 2, Weight = 300f, Price = 220000 },
                new SupplyGood() { Id = 5, GoodId = 6, SupplyId = 3, Weight = 25f, Price = 22899 },
                new SupplyGood() { Id = 6, GoodId = 8, SupplyId = 3, Weight = 100f, Price = 15700 },
                new SupplyGood() { Id = 7, GoodId = 5, SupplyId = 3, Weight = 31f, Price = 39999 }
                );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
