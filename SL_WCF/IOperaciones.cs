using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Suma(int a, int b);//Firma de metodos
        [OperationContract]
         int Resta(int Numero1, int Numero2);
        [OperationContract]
         int Division(int Numero1, int Numero2);
        [OperationContract]
         int Multiplicacion(int Numero1, int Numero2);

        [OperationContract]
        string Saludar(string Nombre);



    }
}
