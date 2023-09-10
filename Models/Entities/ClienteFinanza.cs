using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models.Entities
{
    public class ClienteFinanza
    {
        [Key]
        public int Id_Cliente_Finanza { get; set; }

        public bool INFOCORP { get; set; }

        [StringLength(100)]
        public string ActividadDeCuenta { get; set; }

        [StringLength(100)]
        public string TrabajoFijo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal IngresoMensual { get; set; }

        public int Fk_Cliente { get; set; }

    }
}