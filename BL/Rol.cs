using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllRol()
        {
           ML.Result resultRol = new ML.Result();
            try
            {
                using (DL_EF.KCuevasProgramacioNCapasEntities context = new DL_EF.KCuevasProgramacioNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();
                    resultRol.Objects = new List<object>();


                    if (query != null)
                    {
                        foreach (var RolObject in query)
                        {
                            ML.Rol rol = new ML.Rol();


                            rol.IdRol = RolObject.IdRol;
                            rol.Nombre = RolObject.Nombre;
                            resultRol.Objects.Add(rol);
                        }

                        resultRol.Correct = true;
                    }
                    else
                    {
                        resultRol.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                resultRol.Correct = false;
                resultRol.Message = ex.Message;
                resultRol.Ex = ex;
            }
            return resultRol;
        }
    }
}
