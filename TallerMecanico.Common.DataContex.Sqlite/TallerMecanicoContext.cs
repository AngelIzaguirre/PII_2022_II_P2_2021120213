using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Packt.Shared
{
    public partial class TallerMecanicoContext : DbContext
    {
        public TallerMecanicoContext()
        {
        }

        public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Orden> Ordenes { get; set; } = null!;
        public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlite("Filename=TallerMecanico.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenDetalle>(entity =>
            {
                entity.HasKey(e => new { e.OrdenDetalleId, e.OrdenId });

                entity.HasOne(d => d.OrdenDetalleNavigation)
                    .WithMany(p => p.OrdenDetalles)
                    .HasForeignKey(d => d.OrdenDetalleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
