using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        Result AddEF(ML.Usuario usuario);
        [OperationContract]
        Result UpdateEF(ML.Usuario usuario);
        [OperationContract]
        Result DeleteEF(ML.Usuario usuario);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        Result GetAllEF(ML.Usuario usuario);
    }
}
