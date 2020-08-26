using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeptunoMVC01.Models
{
    [Table("Paises")]
    public class Pais
    {
        public int PaisId { get; set; }
        [Display(Name = "País")]
        public string NombrePais { get; set; }
    }
}