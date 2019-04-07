using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrailsApi.Models
{
    public partial class MyTrailsContext : DbContext
    {
        public MyTrailsContext()
        {
        }

        public MyTrailsContext(DbContextOptions<MyTrailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conditions> Conditions { get; set; }

        public virtual DbSet<PostTrails> PostTrails { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<TrailSections> TrailSections { get; set; }
        public virtual DbSet<Trails> Trails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MyTrails;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");





 

            modelBuilder.Entity<Conditions>(entity =>
            {
                entity.HasIndex(e => e.TrailId)
                    .HasName("IX_TrailId");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TrailId).HasMaxLength(128);

                entity.HasOne(d => d.Trail)
                    .WithMany(p => p.Conditions)
                    .HasForeignKey(d => d.TrailId)
                    .HasConstraintName("FK_dbo.Conditions_dbo.Trails_TrailId");
            });


            modelBuilder.Entity<PostTrails>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TrailId })
                    .HasName("PK_dbo.PostTrails");

                entity.HasIndex(e => e.PostId)
                    .HasName("IX_Post_Id");

                entity.HasIndex(e => e.TrailId)
                    .HasName("IX_Trail_Id");

                entity.Property(e => e.PostId)
                    .HasColumnName("Post_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.TrailId)
                    .HasColumnName("Trail_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTrails)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_dbo.PostTrails_dbo.Posts_Post_Id");

                entity.HasOne(d => d.Trail)
                    .WithMany(p => p.PostTrails)
                    .HasForeignKey(d => d.TrailId)
                    .HasConstraintName("FK_dbo.PostTrails_dbo.Trails_Trail_Id");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TrailSections>(entity =>
            {
                entity.HasIndex(e => e.TrailId)
                    .HasName("IX_TrailID");

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.TrailId)
                    .HasColumnName("TrailID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Trail)
                    .WithMany(p => p.TrailSections)
                    .HasForeignKey(d => d.TrailId)
                    .HasConstraintName("FK_dbo.TrailSections_dbo.Trails_TrailID");
            });

            modelBuilder.Entity<Trails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.InfoHtmllink).HasColumnName("InfoHTMLLink");
            });
        }
    }
}
