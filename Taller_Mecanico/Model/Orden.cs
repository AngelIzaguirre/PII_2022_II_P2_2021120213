using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("Orden")]
    public partial class Orden
    {
        public Orden()
        {
            OrdenDetalles = new HashSet<OrdenDetalle>();
        }

        [Key]
        public int? OrdenId { get; set; } 
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string? ClienteId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaOrden { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Auto { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Matricula { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Marca { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaIngreso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaSalida { get; set; }

        [ForeignKey("ClienteId")]
        [InverseProperty("Ordens")]
        public virtual Cliente? Cliente { get; set; }
        [InverseProperty("OrdenDetalleNavigation")]
        public virtual ICollection<OrdenDetalle>? OrdenDetalles { get; set; }
    }
}
