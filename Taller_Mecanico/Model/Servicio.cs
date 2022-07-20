using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("Servicio")]
    public partial class Servicio
    {
        [Key]
        public int? ServicioId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string? TipoServicio { get; set; } 
        [Column(TypeName = "nnvarchar(200)")]
        public string? Garantia { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? DescripcionProblema { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Costo { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? FechaIngreso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaSalida { get; set; }
    }
}
