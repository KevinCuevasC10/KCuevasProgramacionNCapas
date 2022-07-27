using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
       public static ML.Result MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.MunicipioGetByEstado(IdEstado).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objMunicipio in query)
                        {
                            ML.Municipio municipio = new ML.Municipio();

                            municipio.IdMunicipio = objMunicipio.IdMunicipio;
                            municipio.Nombre = objMunicipio.NombreMunicipio;
                            municipio.Estado = new ML.Estado();
                            municipio.Estado.IdEstado = objMunicipio.IdEstado.Value;

                            result.Objects.Add(municipio);
                            //result.Object = municipio;// almacenar toda la lista en municipio
                            
                        }
                        result.Correct = true; // Validar que el result es correct
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
