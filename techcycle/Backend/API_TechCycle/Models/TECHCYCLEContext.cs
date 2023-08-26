using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_TechCycle.Models
{
    public partial class TECHCYCLEContext : DbContext
    {
        public TECHCYCLEContext()
        {
        }

        public TECHCYCLEContext(DbContextOptions<TECHCYCLEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<FotosAnuncio> FotosAnuncio { get; set; }
        public virtual DbSet<Interesse> Interesse { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TECHCYCLE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.IdAnuncio)
                    .HasName("PK__Anuncio__0BC1EC3EAB01E8A1");

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .HasConstraintName("FK__Anuncio__idAvali__7E02B4CC");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Anuncio__idProdu__7EF6D905");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PK__Avaliaca__2A0C83121DF4BFFA");

                entity.Property(e => e.TipoAvaliacao).IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C8B61A34A");

                entity.Property(e => e.NomeCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__C74515DAB1AD1385");

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdAnuncio)
                    .HasConstraintName("FK__Comentari__idAnu__04AFB25B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comentari__idUsu__05A3D694");
            });

            modelBuilder.Entity<FotosAnuncio>(entity =>
            {
                entity.HasKey(e => e.IdFotosAnuncio)
                    .HasName("PK__FotosAnu__BE006546AC4F90B1");

                entity.Property(e => e.FotoDoAnuncio).IsUnicode(false);

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.FotosAnuncio)
                    .HasForeignKey(d => d.IdAnuncio)
                    .HasConstraintName("FK__FotosAnun__idAnu__01D345B0");
            });

            modelBuilder.Entity<Interesse>(entity =>
            {
                entity.HasKey(e => e.IdInteresse)
                    .HasName("PK__Interess__EC19CAE5F30A3D43");

                entity.Property(e => e.StatusAprovacao).IsUnicode(false);

                entity.HasOne(d => d.IdAnuncioNavigation)
                    .WithMany(p => p.Interesse)
                    .HasForeignKey(d => d.IdAnuncio)
                    .HasConstraintName("FK__Interesse__idAnu__0A688BB1");

                entity.HasOne(d => d.IdUsuarioAprovacaoNavigation)
                    .WithMany(p => p.InteresseIdUsuarioAprovacaoNavigation)
                    .HasForeignKey(d => d.IdUsuarioAprovacao)
                    .HasConstraintName("FK__Interesse__idUsu__09746778");

                entity.HasOne(d => d.IdUsuarioInteressadoNavigation)
                    .WithMany(p => p.InteresseIdUsuarioInteressadoNavigation)
                    .HasForeignKey(d => d.IdUsuarioInteressado)
                    .HasConstraintName("FK__Interesse__idUsu__0880433F");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__7033181217D4289D");

                entity.Property(e => e.NomeMarca).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C38E4E8647");

                entity.Property(e => e.CodIdentificacao).IsUnicode(false);

                entity.Property(e => e.ModeloProduto).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.Property(e => e.Processador).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produto__idCateg__534D60F1");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Produto__idMarca__52593CB8");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A63C85DACA");

                entity.Property(e => e.Departamento).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FotoUsuario).IsUnicode(false);

                entity.Property(e => e.LoginUsuario).IsUnicode(false);

                entity.Property(e => e.NomeCompleto).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.StatusAprovacao).IsUnicode(false);

                entity.Property(e => e.TipoDeUsuario).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
