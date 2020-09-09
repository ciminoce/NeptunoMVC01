using System;
using System.Collections.Generic;
using System.Linq;
using NeptunoMVC01.Context;
using NeptunoMVC01.Models;

namespace NeptunoMVC01.Classes
{
    public class Helper:IDisposable
    {
        private static readonly NeptunoDbContext Context=new NeptunoDbContext();

        public static List<Pais> GetPaises()
        {
            var listaPaises = Context.Paises.ToList();
            listaPaises.Add(new Pais() { PaisId = 0, NombrePais = "[Seleccione País]" });
            return listaPaises.OrderBy(p => p.NombrePais).ToList();

        }

        public static List<Ciudad> GetCiudades()
        {
            var listaCiudades = Context.Ciudades.ToList();
            listaCiudades.Add(new Ciudad() {CiudadId = 0, NombreCiudad = "[Seleccione Ciudad]"});
            return listaCiudades.OrderBy(c => c.NombreCiudad).ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}