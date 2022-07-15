using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datos.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAutor> TblAutors { get; set; } = null!;
        public virtual DbSet<TblLibro> TblLibros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseOracle("User Id=prueba_nexos;Password=123456;Data Source=localhost:1521/xe;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PRUEBA_NEXOS")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TblAutor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("TBL_AUTOR_PK");

                entity.ToTable("TBL_AUTOR");

                entity.Property(e => e.IdAutor).HasColumnType("NUMBER");

                entity.Property(e => e.AutCiudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("autCiudad");

                entity.Property(e => e.AutCorreo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("autCorreo");

                entity.Property(e => e.AutFchNacimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("autFchNacimiento");

                entity.Property(e => e.AutNombreCompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("autNombreCompleto");
            });

            modelBuilder.Entity<TblLibro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("TBL_LIBRO_PK");

                entity.ToTable("TBL_LIBRO");

                entity.Property(e => e.IdLibro).HasColumnType("NUMBER");

                entity.Property(e => e.IdAutor).HasColumnType("NUMBER");

                entity.Property(e => e.LbrAnio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lbrAnio");

                entity.Property(e => e.LbrGenero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lbrGenero");

                entity.Property(e => e.LbrNumPag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("lbrNumPag");

                entity.Property(e => e.LbrTitulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lbrTitulo");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.TblLibros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_LIBROS_CODIGO");
            });

            modelBuilder.HasSequence("IDAUTOR_SEQ");

            modelBuilder.HasSequence("IDLIBRO_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
