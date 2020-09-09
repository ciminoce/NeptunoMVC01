using System.ComponentModel.DataAnnotations;
using NeptunoMVC01.Models;
using PagedList;

namespace NeptunoMVC01.ViewModels.Pais
{
    public class PaisDetailPageListVm
    {
        public int PaisId { get; set; }

        [Display(Name = "País")]
        public string NombrePais { get; set; }
        public IPagedList<Ciudad> Ciudades { get; set; }

    }
}