using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetByIdMunicipio(int IdColonia)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(IdColonia).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objColonia in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();

                            colonia.IdColonia = objColonia.IdColonia;
                            colonia.Nombre = objColonia.NombreColonia;
                            colonia.CodigoPostal = objColonia.CodigoPostal;
                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = objColonia.IdMunicipio.Value;

                            //result.Object = colonia;
                            result.Objects.Add(colonia);
                            
                        }
                        result.Correct = true;
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
