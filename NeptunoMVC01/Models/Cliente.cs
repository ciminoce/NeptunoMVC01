using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeptunoMVC01.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cliente")]

        public string NombreCliente { get; set; }

        [StringLength(255, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cód.Postal")]
        public string CodPostal { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una ciudad")]

        public int CiudadId { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un país")]
        public int PaisId { get; set; }
        public Ciudad Ciudad { get; set; }
        public Pais Pais { get; set; }
    }
}