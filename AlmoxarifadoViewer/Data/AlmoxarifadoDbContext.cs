using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlmoxarifadoViewer.Models
{
    public partial class AlmoxarifadoDbContext : DbContext
    {
        public AlmoxarifadoDbContext()
        {
        }

        public AlmoxarifadoDbContext(DbContextOptions<AlmoxarifadoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AlmoxarifadoViewer;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.ProdutoId).HasColumnName("produtoId");

                entity.Property(e => e.CodigoSap).HasColumnName("codigo_sap");

                entity.Property(e => e.Imagem1)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("imagem1");

                entity.Property(e => e.Imagem2)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("imagem2");

                entity.Property(e => e.Imagem3)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("imagem3");

                entity.Property(e => e.Imagem4)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("imagem4");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
