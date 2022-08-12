using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Usuario.svc o Usuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario
    {
        public Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);//Mandar a llamar al store
            return new Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex };
        }
        public Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Update(usuario);
            return new Result { Correct = result.Correct, Message = result.Message, Ex = result.Ex };

        }

        public Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(usuario);
            return new  Result{ Correct = result.Correct, Message = result.Message, Ex = result.Ex };

        }

        public Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            return new Result { Correct = result.Correct,
                                Message = result.Message,
                                Ex = result.Ex,
                                Object = result.Object,
                                Objects = result.Objects             
                               };
        }

        public Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetById(IdUsuario);
            return new Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
