using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models.Entities
{
    public class Transaccion
    {
        [Key]
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
