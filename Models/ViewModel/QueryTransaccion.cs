using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models.ViewModel
{
    public class QueryTransaccion
    {

        public int Id_Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(100)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [StringLength(20)]
        public string DNI { get; set; }

        public int Edad { get; set; }

        public bool FiguraPublica { get; set; }

        [Range(0, 999.99)]
        public decimal Reputacion { get; set; }

        public int Id_Cliente_Finanza { get; set; }

        public bool INFOCORP { get; set; }

        [StringLength(100)]
        public string ActividadDeCuenta { get; set; }

        [StringLength(100)]
        public string TrabajoFijo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal IngresoMensual { get; set; }

        public int Fk_Cliente { get; set; }


        public int Id_Transaccion { get; set; }

        public DateTime FechaMonto { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MontoTransaccion { get; set; }

        [StringLength(2)]
        public string OrigenDeFondos { get; set; }

        [StringLength(2)]
        public string AgenciaZona { get; set; }

        [StringLength(50)]
        public string LavadoDeActivo { get; set; }

        public int Fk_Cliente_Finanza { get; set; }
    }
}
