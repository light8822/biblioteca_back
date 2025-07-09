using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServicioApi.Models;

public partial class EvaluacionContext : DbContext
{
    public EvaluacionContext()
    {
    }

    public EvaluacionContext(DbContextOptions<EvaluacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleTransaccion> DetalleTransaccions { get; set; }

    public virtual DbSet<Ejemplare> Ejemplares { get; set; }

    public virtual DbSet<Estante> Estantes { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<MedioPago> MedioPagos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TipoTransact> TipoTransacts { get; set; }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=evaluacion;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F5D43838FD");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ubigeo");
        });

        modelBuilder.Entity<DetalleTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DE7509CB71");

            entity.ToTable("Detalle_transaccion");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");
            entity.Property(e => e.IdTransact).HasColumnName("id_transact");
        });

        modelBuilder.Entity<Ejemplare>(entity =>
        {
            entity.HasKey(e => e.IdEjemplar).HasName("PK__Ejemplar__5E0D89ADD849654D");

            entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");
            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEstante).HasColumnName("id_estante");
            entity.Property(e => e.IdItem).HasColumnName("id_item");
            entity.Property(e => e.TipoProd).HasColumnName("tipo_prod");
        });

        modelBuilder.Entity<Estante>(entity =>
        {
            entity.HasKey(e => e.IdEstante).HasName("PK__Estantes__3CBB3E3BD46E4866");

            entity.Property(e => e.IdEstante).HasColumnName("id_estante");
            entity.Property(e => e.Categoria)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__EC09C24EB3CBDCA5");

            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Genero)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAlquiler)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio_alquiler");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio_venta");
        });

        modelBuilder.Entity<MedioPago>(entity =>
        {
            entity.HasKey(e => e.IdMedio).HasName("PK__Medio_pa__2112D17E91C46B78");

            entity.ToTable("Medio_pago");

            entity.Property(e => e.IdMedio).HasColumnName("id_medio");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__0941B074E8F9CCC2");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdMedio).HasColumnName("id_medio");
            entity.Property(e => e.IdTransaccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("id_transaccion");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__Perfil__1D1C876823A5A738");

            entity.ToTable("Perfil");

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Clientes).HasColumnName("clientes");
            entity.Property(e => e.ListaNegra).HasColumnName("lista_negra");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Reportes).HasColumnName("reportes");
            entity.Property(e => e.Usuarios).HasColumnName("usuarios");
            entity.Property(e => e.Ventas).HasColumnName("ventas");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0DDC24E3FC");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio_venta");
        });

        modelBuilder.Entity<TipoTransact>(entity =>
        {
            entity.HasKey(e => e.IdTipotran).HasName("PK__Tipo_tra__15C3C26142EF4073");

            entity.ToTable("Tipo_transact");

            entity.Property(e => e.IdTipotran).HasColumnName("id_tipotran");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.IdTransact).HasName("PK__Transacc__FCA3EE390C6FDD54");

            entity.ToTable("Transaccion");

            entity.Property(e => e.IdTransact).HasColumnName("id_transact");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaRetorno).HasColumnName("fecha_retorno");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdTipotran).HasColumnName("id_tipotran");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuarios__D2D1463724A49938");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
