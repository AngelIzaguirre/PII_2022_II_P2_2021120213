using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("OrdenDetalle")]
    public partial class OrdenDetalle
    {
        [Key]
        public int OrdenDetalleId { get; set; }
        [Key]
        public int OrdenId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaOrden { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? TipoServicio { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Auto { get; set; }
        [Column(TypeName = "varChar(12)")]
        public string? Matricula { get; set; }
        [Column(TypeName = "varchar(24)")]
        public string? Marca { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Costo { get; set; }

        [ForeignKey("OrdenDetalleId")]
        [InverseProperty("OrdenDetalles")]
        public virtual Orden OrdenDetalleNavigation { get; set; } = null!;
    }
}
