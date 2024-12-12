﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CarWashBackend.Models;

public partial class CarwashContext : DbContext
{
    public CarwashContext()
    {
    }

    public CarwashContext(DbContextOptions<CarwashContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<EstadosServicio> EstadosServicios { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Permiso> Permisos { get; set; }
    public virtual DbSet<RegistroServicio> RegistroServicios { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Servicio> Servicios { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseMySql(
            "server=localhost;database=Carwash;uid=root;pwd=P@ssWord.123",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        // Aplica todas las configuraciones de entidad
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarwashContext).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
