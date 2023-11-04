using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Turnero.Entity;

namespace Turnero.DAL.DBContext;

public partial class TurneroContext : DbContext
{
    public TurneroContext()
    {
    }

    public TurneroContext(DbContextOptions<TurneroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AtendidoPor> AtendidoPors { get; set; }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<EstadoCitas> EstadoCita { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TurnoCita> TurnoCitas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //> optionsBuilder.UseSqlServer("Server=(local); Database=turnero; Integrated Security=true; Encrypt=false;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AtendidoPor>(entity =>
        {
            entity.HasKey(e => e.IdAtendido).HasName("PK__atendido__A41B8C57A8C502B5");

            entity.ToTable("atendido_por");

            entity.Property(e => e.IdAtendido).HasColumnName("id_atendido");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.AtendidoPors)
                .HasForeignKey(d => d.IdCita)
                .HasConstraintName("FK__atendido___id_ci__52593CB8");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.AtendidoPors)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__atendido___id_pe__534D60F1");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__cita__6AEC3C091339E8CB");

            entity.ToTable("cita");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdEstadoCita).HasColumnName("id_estado_cita");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdTurnoCita).HasColumnName("id_turno_cita");

            entity.HasOne(d => d.IdEstadoCitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEstadoCita)
                .HasConstraintName("FK__cita__id_estado___4E88ABD4");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__cita__id_persona__4F7CD00D");

            entity.HasOne(d => d.IdTurnoCitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdTurnoCita)
                .HasConstraintName("FK__cita__id_turno_c__656C112C");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__64F37A16600D5622");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadoCitas>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCita).HasName("PK__estado_c__37DAEF1DAA602977");

            entity.ToTable("estado_cita");

            entity.Property(e => e.IdEstadoCita).HasColumnName("id_estado_cita");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__menu__4CA0FADC37328714");

            entity.ToTable("menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Rol).WithMany(p => p.Menus)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__menu__rol_id__398D8EEE");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__municipi__01C9EB99DEB8191F");

            entity.ToTable("municipio");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdDeprtamento).HasColumnName("id_deprtamento");

            entity.HasOne(d => d.IdDeprtamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDeprtamento)
                .HasConstraintName("FK__municipio__id_de__4316F928");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__persona__228148B0E765946D");

            entity.ToTable("persona");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Nombres)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NroCelular)
                .IsUnicode(false)
                .HasColumnName("nro_celular");
            entity.Property(e => e.NroDocumentos)
                .IsUnicode(false)
                .HasColumnName("nro_documentos");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__persona__id_muni__45F365D3");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK__persona__id_tipo__46E78A0C");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__6ABCB5E0232E93F3");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__tipo_doc__9F38507C8BD3A254");

            entity.ToTable("tipo_documento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TurnoCita>(entity =>
        {
            entity.HasKey(e => e.IdTurnoCita).HasName("PK__turno_ci__8485AD9183B2900A");

            entity.ToTable("turno_citas");

            entity.Property(e => e.IdTurnoCita).HasColumnName("id_turno_cita");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaAtencion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_atencion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__usuarios__2ED7D2AF29206C42");

            entity.ToTable("usuarios");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Clave)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Usuario1)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__usuarios__id_per__47DBAE45");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__usuarios__rol_id__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
