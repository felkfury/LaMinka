using System;
using LaMinka.Logica.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LaMinka.Logica.Data
{
    public partial class LaMinkaContext : DbContext
    {
        public LaMinkaContext()
        {
        }

        public LaMinkaContext(DbContextOptions<LaMinkaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteDomicilio> ClienteDomicilio { get; set; }
        public virtual DbSet<PaquetePedido> PaquetePedido { get; set; }
        public virtual DbSet<PaquetePedidoProducto> PaquetePedidoProducto { get; set; }
        public virtual DbSet<PaquetePedidoReparto> PaquetePedidoReparto { get; set; }
        public virtual DbSet<PaquetePedidoRepartoEstado> PaquetePedidoRepartoEstado { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoValor> ProductoValor { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-EIL5BL1I\\LOCAL;Database=LaMinka;Trusted_Connection=True;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ClienteDomicilio>(entity =>
            {
                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Caracteristicas).HasMaxLength(500);

                entity.Property(e => e.Depto)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EntreCalle).HasMaxLength(150);

                entity.Property(e => e.EntreCalle2).HasMaxLength(150);

                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PreguntarPor).HasMaxLength(150);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteDomicilio)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteDomicilios_Clientes");
            });


            modelBuilder.Entity<PaquetePedido>(entity =>
            {
                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaEntrega).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<PaquetePedidoProducto>(entity =>
            {
                entity.HasOne(d => d.IdPaquetePedidoNavigation)
                    .WithMany(p => p.PaquetePedidoProducto)
                    .HasForeignKey(d => d.IdPaquetePedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoProductos_PaquetePedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.PaquetePedidoProducto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoProductos_Productos");
            });

            modelBuilder.Entity<PaquetePedidoReparto>(entity =>
            {
                entity.Property(e => e.Comentarios).HasMaxLength(500);

                entity.Property(e => e.FechaEntrega).HasColumnType("smalldatetime");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.PaquetePedidoReparto)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoReparto_PaquetePedidoRepartoEstado");

                entity.HasOne(d => d.IdPaquetePedidoNavigation)
                    .WithMany(p => p.PaquetePedidoReparto)
                    .HasForeignKey(d => d.IdPaquetePedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoReparto_PaquetePedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PaquetePedidoReparto)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoReparto_Pedidos");

                entity.HasOne(d => d.IdRepartidorNavigation)
                    .WithMany(p => p.PaquetePedidoReparto)
                    .HasForeignKey(d => d.IdRepartidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaquetePedidoReparto_User");
            });

            modelBuilder.Entity<PaquetePedidoRepartoEstado>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaPedido).HasColumnType("smalldatetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Clientes");

                entity.HasOne(d => d.IdClienteDomicilioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdClienteDomicilio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_ClienteDomicilios");

                entity.HasOne(d => d.IdPaquetePedidoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdPaquetePedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_PaquetePedido");
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoDetalle)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoDetalle_Pedidos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");

                entity.Property(e => e.FotoUrl).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ProductoValor>(entity =>
            {
                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FechaAlta).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaBaja).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModif).HasColumnType("smalldatetime");

                entity.Property(e => e.Importe).HasColumnType("money");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductoValor)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoValores_Productos");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BirthDate)
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserToken)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ZonaPoligono).HasMaxLength(500);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}





