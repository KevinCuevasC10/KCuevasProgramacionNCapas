using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Ocupar la libreria System Data
using System.Data.SqlClient;

namespace BL
{
    public class Pais
    {
        public static ML.Result PaisGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.PaisGetAll().ToList();
                    result.Objects = new List<object>();

                    if(query!= null)
                    {
                        foreach (var objPais in query)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = objPais.IdPais;
                            pais.Nombre = objPais.Nombre;

                            result.Objects.Add(pais);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }                    
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
