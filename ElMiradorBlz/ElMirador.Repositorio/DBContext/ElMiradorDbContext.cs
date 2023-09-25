using System;
using System.Collections.Generic;
using ElMirador.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ElMirador.Repositorio.DBContext;

public partial class ElMiradorDbContext : DbContext
{
    public ElMiradorDbContext()
    {
    }

    public ElMiradorDbContext(DbContextOptions<ElMiradorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acta> Actas { get; set; }

    public virtual DbSet<Asamblea> Asambleas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voto> Votos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__actas__3213E83F9BA45EAC");

            entity.ToTable("actas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdAsamblea).HasColumnName("id_asamblea");
            entity.Property(e => e.Tema)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tema");
            entity.Property(e => e.Votaciones)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("votaciones");

            entity.HasOne(d => d.IdAsambleaNavigation).WithMany(p => p.Acta)
                .HasForeignKey(d => d.IdAsamblea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__actas__id_asambl__3E52440B");
        });

        modelBuilder.Entity<Asamblea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__asamblea__3213E83F96A0F587");

            entity.ToTable("asambleas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Agenda)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("agenda");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.Lugar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lugar");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83F41BAF957");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("numero_identificacion");
        });

        modelBuilder.Entity<Voto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__votos__3213E83F9071E6C5");

            entity.ToTable("votos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdAsamblea).HasColumnName("id_asamblea");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.VotoEmitido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("voto_emitido");

            entity.HasOne(d => d.IdAsambleaNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdAsamblea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__votos__id_asambl__3A81B327");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__votos__id_usuari__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
