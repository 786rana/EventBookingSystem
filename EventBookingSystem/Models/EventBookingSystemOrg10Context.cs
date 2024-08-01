using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Models;

public partial class EventBookingSystemOrg10Context : DbContext
{
    public EventBookingSystemOrg10Context()
    {
    }

    public EventBookingSystemOrg10Context(DbContextOptions<EventBookingSystemOrg10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MarriageHall> MarriageHalls { get; set; }

    public virtual DbSet<MarriageHallService> MarriageHallServices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Servicess> Servicesses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EventBookingSystemORG10;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarriageHall>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_MarriageHalls_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.MarriageHalls).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<MarriageHallService>(entity =>
        {
            entity.HasIndex(e => e.MarriageHallId, "IX_MarriageHallServices_MarriageHallId");

            entity.HasOne(d => d.MarriageHall).WithMany(p => p.MarriageHallServices).HasForeignKey(d => d.MarriageHallId);

            entity.HasOne(d => d.Service).WithMany(p => p.MarriageHallServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarriageHallServices_Servicess");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Tip).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MarriageHall).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MarriageHallId)
                .HasConstraintName("FK_Orders_MarriageHalls");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<Servicess>(entity =>
        {
            entity.ToTable("Servicess");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
