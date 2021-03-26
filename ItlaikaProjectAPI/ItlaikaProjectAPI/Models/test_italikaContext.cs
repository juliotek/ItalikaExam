using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ItlaikaProjectAPI.Models
{
    public partial class test_italikaContext : DbContext
    {
        public test_italikaContext()
        {
        }

        public test_italikaContext(DbContextOptions<test_italikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CType> CTypes { get; set; }
        public virtual DbSet<TbProduct> TbProducts { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;user=sa;password=julio42684;database=TEST_ITALIKA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CType>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.ToTable("cTypes");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("tbProducts");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Fert)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fert");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Serie)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sku");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TbProducts)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProducts_cTypes");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("tbUsers");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
