using Microsoft.EntityFrameworkCore;
using IncidentLibrary.Data.Models;

namespace IncidentLibrary.Data.Context
{
    public partial class IncidentLibraryContext : DbContext
    {
        public IncidentLibraryContext()
        {
        }

        public IncidentLibraryContext(DbContextOptions<IncidentLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incident> Incidents { get; set; } = null!;
        public virtual DbSet<Label> Labels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=MySQL:ConnectionString", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_bin")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("incident");

                entity.HasComment("事件");

                entity.HasIndex(e => e.Labels, "idx_tags");

                entity.HasIndex(e => e.Title, "idx_title");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("自增ID");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("事件详细描述");

                entity.Property(e => e.Labels)
                    .HasMaxLength(100)
                    .HasColumnName("labels")
                    .HasComment("每个标签用分号隔开");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title")
                    .HasComment("事件标题");
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.ToTable("label");

                entity.HasComment("标签");

                entity.HasIndex(e => e.Name, "idx_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("自增ID");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasDefaultValueSql("'2'")
                    .HasComment("标签颜色");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name")
                    .HasComment("标签名称");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
