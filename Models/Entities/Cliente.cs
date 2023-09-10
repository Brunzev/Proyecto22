using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Entities
{
    public class Cliente
    {
        [Key]
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

    }
}