using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Ordens = new HashSet<Orden>();
        }

        [Key]
        [Column(TypeName = "nvarchar(25)")]
        [RegularExpression("A-Z{5}")]
        public string? ClienteId { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string? Nombre { get; set; } = null!;
        [Column(TypeName = "nvarchar(80)")]
        public string? Direccion { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        public string? Auto { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Matricula { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaNacimiento { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string? Telefono { get; set; }

        [InverseProperty("Cliente")]
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
