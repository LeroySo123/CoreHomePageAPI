using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreHomePageAPI.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BannerList> BannerLists { get; set; }
        public virtual DbSet<EventList> EventLists { get; set; }
        public virtual DbSet<LinkList> LinkLists { get; set; }
        public virtual DbSet<NewList> NewLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BannerList>(entity =>
            {
                entity.HasKey(e => e.BannerId);

                entity.ToTable("BannerList");

                entity.Property(e => e.BannerId).HasColumnName("BannerID");

                entity.Property(e => e.BannerDescription).HasMaxLength(500);

                entity.Property(e => e.BannerTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImgLink).IsRequired();

                entity.Property(e => e.Url).HasColumnName("URL");
            });

            modelBuilder.Entity<EventList>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EventLis__7944C8704C8DD167");

                entity.ToTable("EventList");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EventEndDate).HasColumnType("datetime");

                entity.Property(e => e.EventStartDate).HasColumnType("datetime");

                entity.Property(e => e.EventTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LinkList>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.ToTable("LinkList");

                entity.Property(e => e.LinkId).HasColumnName("LinkID");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<NewList>(entity =>
            {
                entity.HasKey(e => e.NewId);

                entity.ToTable("NewList");

                entity.Property(e => e.NewId).HasColumnName("NewID");

                entity.Property(e => e.ActiveDate).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.NewDetail).IsRequired();

                entity.Property(e => e.NewName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
