using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Ocupar la libreria System Data
using System.Data.SqlClient;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {                        
                        foreach (var objEstado in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = objEstado.IdEstado;
                            estado.Nombre = objEstado.Nombre;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = objEstado.IdPais.Value;
                           
                           result.Objects.Add(estado);
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
