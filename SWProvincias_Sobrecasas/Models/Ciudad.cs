using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWProvincias_Sobrecasas.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public int ProvinciaId { get; set; }

        [ForeignKey("ProvinciaId")]
        public Provincia provincia { get; set; }
    }
}
