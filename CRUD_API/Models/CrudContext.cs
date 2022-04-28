using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRUD_API.Models
{
    public partial class CrudContext : DbContext
    {
        public CrudContext()
        {
        }

        public CrudContext(DbContextOptions<CrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutosCategorias> ProdutosCategorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.CategoriaNome)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime")
                .IsRequired();

                entity.Property(e => e.Descricao).IsRequired();

                entity.Property(e => e.Imagem).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ProdutosCategorias>(entity =>
            {
                
                entity.Property(e => e.ProdutoId)
                    .IsRequired();
                entity.Property(e => e.CategoriaId)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
