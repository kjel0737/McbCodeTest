using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace McbCodeTest.Model
{
    public partial class McbDatabase : DbContext
    {
        public McbDatabase()
        {
        }

        public McbDatabase(DbContextOptions<McbDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemText> ItemTexts { get; set; }
        public virtual DbSet<ItemVariantOption> ItemVariantOptions { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<VariantOption> VariantOptions { get; set; }
        public virtual DbSet<VariantOptionText> VariantOptionTexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=mcbtest.database.windows.net;Database=kej;User Id=kej;Password=ion23!UB782;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Item__ParentID__5FB337D6");
            });

            modelBuilder.Entity<ItemText>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemTexts)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemText__ItemID__628FA481");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ItemTexts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemText__Langua__6383C8BA");
            });

            modelBuilder.Entity<ItemVariantOption>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.VariantOptionId })
                    .HasName("PK__ItemVari__EC2DDBB051A409BA");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemVariantOptions)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemVaria__ItemI__70DDC3D8");

                entity.HasOne(d => d.VariantOption)
                    .WithMany(p => p.ItemVariantOptions)
                    .HasForeignKey(d => d.VariantOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemVaria__Varia__71D1E811");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<VariantOption>(entity =>
            {
                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.VariantOptions)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantOp__Varia__693CA210");
            });

            modelBuilder.Entity<VariantOptionText>(entity =>
            {
                entity.HasKey(e => new { e.VariantOptionId, e.LanguageId })
                    .HasName("PK__VariantO__4EA600E0B5029AA8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.VariantOptionTexts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantOp__Langu__6E01572D");

                entity.HasOne(d => d.VariantOption)
                    .WithMany(p => p.VariantOptionTexts)
                    .HasForeignKey(d => d.VariantOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantOp__Varia__6D0D32F4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
