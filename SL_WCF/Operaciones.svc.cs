using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
            public int Suma(int a, int b) 
            {

                int Resultado = a + b;
                return Resultado;
            }
            
            public int Resta(int Numero1, int Numero2)
            {
                int Resultado = Numero1 - Numero2;
                return Resultado;
            }
            
            public int Division(int Numero1, int Numero2)
            {
                int Resultado = Numero1 / Numero2;
                return Resultado;
            }

            public int Multiplicacion(int Numero1, int Numero2)
            {
                int Resultado = Numero1 * Numero2;
                return Resultado;
            }

            public string Saludar(string Nombre)
            {
                return string.Format("Hola"+Nombre);
            }




    }
}
